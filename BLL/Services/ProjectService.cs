using AutoMapper;
using BLL.DTO;
using BLL.Services.Base;
using DAL.Base;
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
                //TO DO: same
            }
        }



    }
}
