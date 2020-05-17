using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Base;
using BLL.Services.Interfaces;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    //TODO: add XML annotations to non-trivial methods
    internal class ProjectService : BaseService, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task AddPerformerAsync(ProjectDTO projectDTO, UserDTO performer)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException(searchedProject.Title);

            var searchedPerformer = await _unitOfWork.UserRepository
                    .GetByIdAsync(performer.Id);

            if (searchedPerformer == null)
                throw new NotFoundException(searchedPerformer.Name);

            searchedProject.Users.Add(searchedPerformer);
            searchedPerformer.Project = searchedProject;

            await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
            await _unitOfWork.UserRepository.UpdateAsync(searchedPerformer);
        }

        public async Task ChangeDescriptionAsync(ProjectDTO projectDTO, string description)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException(searchedProject.Title);

            searchedProject.Description = description;

            await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
        }

        public async Task ChangeManagerAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException(searchedProject.Title);

            var searchedUser = await _unitOfWork.UserRepository
                    .GetByIdAsync(manager.Id);

            if (searchedUser == null)
                throw new NotFoundException(searchedUser.Name);

            if (searchedUser.Role != UserRole.Manager)
            {
                //TODO: add exception / maybe this check wont be needed
            }

            searchedUser.Project = searchedProject;
            searchedProject.ProjectManager = searchedUser;

            await _unitOfWork.UserRepository.UpdateAsync(searchedUser);
            await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
        }

        public async Task CreateProjectAsync(ProjectDTO projectDTO)
        {
            var mappedProject = _mapper.Map<Project>(projectDTO);

            await _unitOfWork.ProjectRepository.AddAsync(mappedProject);
        }

        public async Task DeleteProjectAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByIdAsync(manager.Id);

            if (searchedUser == null)
                throw new NotFoundException(searchedUser.Name);

            var searchedProject = await _unitOfWork.ProjectRepository
                    .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException(searchedProject.Title);

            if (searchedUser.Role != UserRole.Manager)
            {
                //exception
            }

            var projects = await _unitOfWork.ProjectRepository
                .GetAllAsync();

            //prbbly should change it
            bool isCurrentProjectManager = projects
                .Exists(x => x.ProjectManager.Id == manager.Id);

            if (isCurrentProjectManager)
            {
                await _unitOfWork.ProjectRepository.DeleteAsync(searchedProject);
            }
            else
            {
                //exception or result
            }
        }

        public async Task<IEnumerable<ProjectDTO>> GetByManagerAsync(string name)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByCriteriaAsync(x => x.Name == name);

            if (searchedUser == null)
                throw new NotFoundException(searchedUser.Name);

            var projects = await _unitOfWork.ProjectRepository
                .GetAllAsync();

            var projectsByManager = projects
                .Where(x => x.ProjectManager.Name == name).ToList();

            if (projectsByManager == null || projectsByManager.Count == 0)
                throw new NotFoundException("");

            return _mapper.ProjectTo<ProjectDTO>(projectsByManager as IQueryable);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var searcherProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(id);

            if (searcherProject == null)
                throw new NotFoundException(searcherProject.Title);

            return _mapper.Map<ProjectDTO>(searcherProject);
        }
    }
}
