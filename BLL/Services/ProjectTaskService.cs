using AutoMapper;
using BLL.DTO;
using BLL.Exceptions;
using BLL.Services.Base;
using DAL.Entities;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    class ProjectTaskService : BaseService
    {
        public ProjectTaskService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task AssignPerformerAsync(ProjectTaskDTO projectTaskDTO, UserDTO performer)
        {
            var searchedTask = await _unitOfWork.ProjectTaskRepository
                .GetByIdAsync(projectTaskDTO.Id);

            if (searchedTask == null)
                throw new NotFoundException(searchedTask.Title);

            var searchedUser = await _unitOfWork.UserRepository
                .GetByIdAsync(performer.Id);

            if (searchedUser == null)
                throw new NotFoundException(searchedUser.Name);

            searchedTask.Performer = searchedUser;
            searchedUser.Tasks.Add(searchedTask);

            await _unitOfWork.ProjectTaskRepository.
                UpdateAsync(searchedTask);

            await _unitOfWork.UserRepository.
                UpdateAsync(searchedUser);
        }

        public async Task CreateTaskAsync(ProjectTaskDTO projectTaskDTO)
        {
            var taskExist = await _unitOfWork.ProjectTaskRepository
                .GetByCriteriaAsync(x => x.Title == projectTaskDTO.Title) != null;

            if (taskExist) throw new Exception("already exists");//gotta change

            var mappedTask = _mapper.Map<ProjectTask>(projectTaskDTO);

            await _unitOfWork.ProjectTaskRepository
                .AddAsync(mappedTask);
        }

        public async Task ChangeDesriptionAsync(ProjectTaskDTO projectTaskDTO, string description)
        {
            var searchedTask = await _unitOfWork.ProjectTaskRepository
                .GetByIdAsync(projectTaskDTO.Id);

            if (searchedTask == null)
                throw new NotFoundException(searchedTask.Title);

            searchedTask.Description = description;

            await _unitOfWork.ProjectTaskRepository
                .UpdateAsync(searchedTask);
        }


    }
}
