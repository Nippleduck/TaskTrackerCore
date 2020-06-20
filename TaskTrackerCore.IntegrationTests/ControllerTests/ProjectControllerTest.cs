using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerCore.IntegrationTests.TestConfigurations;
using Xunit;
using Moq;
using BLL.Services.Interfaces;
using BLL.DTO;
using API.Controllers;

namespace TaskTrackerCore.IntegrationTests.ControllerTests
{
    public class ProjectControllerTest : IClassFixture<IntegrationTestFixture>
    {
        readonly IntegrationTestFixture _fixture;

        public ProjectControllerTest(IntegrationTestFixture fixture) =>
            _fixture = fixture;
     

        [Fact]
        public async Task Method()
        {
            var client = _fixture.CreateClient();
            var result = await client.GetAsync("/project/1");
            var data = await result.Content.ReadAsStringAsync();
            result.EnsureSuccessStatusCode();

            var mock = new Mock<IProjectService>();
            mock.Setup(a => a.GetProjectByIdAsync(1)).Returns(new Task<ProjectDTO>(() => new ProjectDTO { Title = "test" }));

            ProjectController controller = new ProjectController(mock.Object);
            var project = controller.GetProject(1);

            Assert.Equal(project.Result.ToString(), data);
            //Assert.Equal(mock.Object.GetProjectByIdAsync(1).Result.ToString(), data);
        }
    }
}
