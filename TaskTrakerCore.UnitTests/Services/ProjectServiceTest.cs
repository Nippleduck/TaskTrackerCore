using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using DAL.UnitOfWork;
using DAL.Entities;
using System.Threading.Tasks;
using BLL.DTO;
using TaskTrakerCore.UnitTests.TestConfigurations;

namespace TaskTrakerCore.UnitTests.Services
{
    public class ProjectServiceTest : TestBaseFixture
    {
        readonly IProjectService projectService;
        public ProjectServiceTest() : base() =>
            projectService = new ProjectService(new UnitOfWork(Context), Mapper);

        [Theory]
        [InlineData(1)]
        public void ShouldReturnExpectedProjectWitTitle(int id)
        {

            var result = projectService.GetProjectByIdAsync(id);
       
            var expectedProject = new Project { Title = "Web application" };

            Assert.Equal(expectedProject.Title, result.Result.Title);
        }
    }
}
