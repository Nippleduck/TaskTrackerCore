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
    public class ProjectService : BaseService, IProjectService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task AddPerformerAsync(ProjectDTO projectDTO, UserDTO performer)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException($"Project {projectDTO.Title} not found");

            var searchedPerformer = await _unitOfWork.UserRepository
                    .GetByIdAsync(performer.Id);

            if (searchedPerformer == null)
                throw new NotFoundException($"User {performer.Name} not found");

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
                throw new NotFoundException($"Project {searchedProject.Title} not found");

            searchedProject.Description = description;

            await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
        }

        public async Task ChangeManagerAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException($"Project {searchedProject.Title} not found");

            var searchedUser = await _unitOfWork.UserRepository
                    .GetByIdAsync(manager.Id);

            if (searchedUser == null)
                throw new NotFoundException($"User {searchedUser.Name} not found");

            searchedUser.Project = searchedProject;
            searchedProject.ProjectManager = searchedUser;

            await _unitOfWork.UserRepository.UpdateAsync(searchedUser);
            await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
        }

        public async Task CreateProjectAsync(ProjectDTO projectDTO)
        {
            var projectExist = await _unitOfWork.ProjectRepository
                .GetByCriteriaAsync(p => p.Title == projectDTO.Title) != null;

            if (projectExist) throw new EntityDuplicateException($"Project {projectDTO.Title} already exist");

            var mappedProject = _mapper.Map<Project>(projectDTO);

            await _unitOfWork.ProjectRepository.AddAsync(mappedProject);
        }

        public async Task DeleteProjectAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByIdAsync(manager.Id);

            if (searchedUser == null)
                throw new NotFoundException($"User {searchedUser.Name} not found");

            var searchedProject = await _unitOfWork.ProjectRepository
                    .GetByIdAsync(projectDTO.Id);

            if (searchedProject == null)
                throw new NotFoundException($"Project {searchedProject.Title} not found");

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
                throw new NotFoundException($"User {searchedUser.Name} not found");

            var projects = await _unitOfWork.ProjectRepository
                .GetAllAsync();

            var projectsByManager = projects
                .Where(x => x.ProjectManager.Name == name).ToList();

            if (projectsByManager == null || projectsByManager.Count == 0)
                throw new NotFoundException($"Projects managed by user {name} not found");

            return _mapper.ProjectTo<ProjectDTO>(projectsByManager as IQueryable);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var searcherProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(id);

            if (searcherProject == null)
                throw new NotFoundException($"Project {searcherProject.Title} not found");

            return _mapper.Map<ProjectDTO>(searcherProject);
        }
    }
}
