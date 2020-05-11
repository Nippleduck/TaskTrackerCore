using BLL.DTO;
using BLL.Services;
using DAL.Entities;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BLL.Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    public class ProjectController : ControllerBase
    {
        public ProjectController(IProjectService projectService) =>
            _projectService = projectService;

        readonly IProjectService _projectService;

        [HttpGet]
        [Route("project/{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectService.
                GetProjectByIdAsync(id);

            return Ok(project);
        }

        [HttpPost]
        [Route("project/add")]
        public async Task<IActionResult> AddProjectAsync([FromBody] ProjectDTO projectDTO)
        {
            await _projectService.CreateProjectAsync(projectDTO);

            return Ok();
        }
    }
}
