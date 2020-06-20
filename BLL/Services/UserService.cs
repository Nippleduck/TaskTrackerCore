using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class UserService : BaseService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task CreateUserAsync(UserDTO userDTO)
        {
            var userExist = await _unitOfWork.UserRepository
                .GetByCriteriaAsync(u => u.Name == userDTO.Name) != null;

            if (userExist) throw new EntityDuplicateException($"User with name {userDTO.Name} already exists");

            var mappedUser = _mapper.Map<ProjectUser>(userDTO);

            await _unitOfWork.UserRepository.AddAsync(mappedUser);
        }

        public async Task<UserDTO> GetUserByNameAsync(string name)
        {
            var searchedUser = await _unitOfWork.UserRepository.GetByCriteriaAsync(u => u.Name == name);

            if (searchedUser == null) throw new NotFoundException($"User {name} not found");

            var mappedUser = _mapper.Map<UserDTO>(searchedUser);

            return mappedUser;
        }

        public async Task ExchangeRefreshTokenAsync(string oldToken, string newToken, string identityId)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByCriteriaAsync(u => u.ApplicationUserId == identityId);

            if (searchedUser == null) throw new NotFoundException("User with that Id not found");

            if (!searchedUser.HasValidRefreshToken(oldToken))
                throw new InvalidTokenException("User has no valid token");

            searchedUser.RemoveRefreshToken(oldToken);
            searchedUser.AddRefreshToken(newToken, identityId);

            await _unitOfWork.UserRepository.UpdateAsync(searchedUser);
        }

        public async Task AddRefreshTokenAsync(string refreshToken, string identityId)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByCriteriaAsync(u => u.ApplicationUserId == identityId);

            if (searchedUser == null) throw new NotFoundException("User with that Id not found");

            searchedUser.AddRefreshToken(refreshToken, identityId);

            await _unitOfWork.UserRepository.UpdateAsync(searchedUser);
        }
    }
}
