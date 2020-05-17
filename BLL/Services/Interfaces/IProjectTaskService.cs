using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IProjectTaskService
    {
        Task AssignPerformerAsync(ProjectTaskDTO projectTaskDTO, UserDTO performer);
        Task CreateTaskAsync(ProjectTaskDTO projectTaskDTO);
        Task ChangeDesriptionAsync(ProjectTaskDTO projectTaskDTO, string description);
    }
}
