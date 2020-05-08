using AutoMapper;
using BLL.DTO;
using BLL.Services.Base;
using DAL.Entities;
using DAL.Entities.Enums;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    //TODO: add XML annotations to non-trivial methods
    public class ProjectService : BaseService
    {
        public ProjectService(IUnitOfWork unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper) { }

        public async Task AddPerformerAsync(ProjectDTO projectDTO, UserDTO performer)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if (searchedProject != null)
            {
                var searchedPerformer = await _unitOfWork.UserRepository
                    .GetByIdAsync(performer.Id);

                if (searchedPerformer != null)
                {
                    searchedProject.Users.Add(searchedPerformer);
                    searchedPerformer.ProjectId = searchedProject.Id;

                    await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
                    await _unitOfWork.UserRepository.UpdateAsync(searchedPerformer);
                }
                else
                {
                    //TO DO: add some custom exceptions or result object
                }
            }
            else
            {
                //TO DO: exception {not found}
            }
        }

        public async Task ChangeDescriptionAsync(ProjectDTO projectDTO, string description)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if(searchedProject != null)
            {
                searchedProject.Description = description;

                await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
            }
            else
            {
                //exception {not found}
            }
        }

        public async Task ChangeManagerAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedProject = await _unitOfWork.ProjectRepository
                .GetByIdAsync(projectDTO.Id);

            if(searchedProject != null)
            {
                var searchedUser = await _unitOfWork.UserRepository
                    .GetByIdAsync(manager.Id);

                if (searchedUser != null)
                {
                    if(searchedUser.Role != UserRole.Manager)
                    {
                        //TODO: add exception / maybe this check wont be needed
                    }

                    searchedUser.Project = searchedProject;
                    searchedProject.Manager = searchedUser;

                    await _unitOfWork.UserRepository.UpdateAsync(searchedUser);
                    await _unitOfWork.ProjectRepository.UpdateAsync(searchedProject);
                }
                else
                {
                    //TODO: add exception {not found exception}
                }
            }
        }

        public async Task CreateProjectAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByIdAsync(manager.Id);

            if (searchedUser != null)
            {
                if(searchedUser.Role != UserRole.Manager)
                {
                    //Exception {inapropriate role}
                }

                var mappedProject = _mapper.Map<Project>(projectDTO);

                await _unitOfWork.ProjectRepository.AddAsync(mappedProject);
            }
            else
            {
                //Exception {not found}
            }
        }

        public async Task DeleteProjectAsync(ProjectDTO projectDTO, UserDTO manager)
        {
            var searchedUser = await _unitOfWork.UserRepository
                .GetByIdAsync(manager.Id);

            if(searchedUser != null)
            {
                var searchedProject = await _unitOfWork.ProjectRepository
                    .GetByIdAsync(projectDTO.Id);

                if(searchedProject != null)
                {
                    if (searchedUser.Role != UserRole.Manager)
                    {
                        //exception
                    }

                    var projects = await _unitOfWork.ProjectRepository
                        .GetAllAsync();

                    //prbbly should change it
                    bool isProjectManager = projects
                        .Exists(x => x.Manager.Id == manager.Id);

                    if (isProjectManager)
                    {
                        await _unitOfWork.ProjectRepository.DeleteAsync(searchedProject);
                    }
                    else
                    {
                        //exception or result
                    }
                }
                else
                {

                }
            }
            else
            {
                
            }
        }

    }
}
