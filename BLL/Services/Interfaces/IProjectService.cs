﻿using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IProjectService
    {
        Task AddPerformerAsync(ProjectDTO projectDTO, UserDTO performer);
        Task ChangeDescriptionAsync(ProjectDTO projectDTO, string description);
        Task ChangeManagerAsync(ProjectDTO projectDTO, UserDTO manager);
        Task CreateProjectAsync(ProjectDTO projectDTO);
        Task DeleteProjectAsync(ProjectDTO projectDTO, UserDTO manager);
        Task<IEnumerable<ProjectDTO>> GetByManagerAsync(string name);
        Task<ProjectDTO> GetProjectByIdAsync(int id);
    }
}
