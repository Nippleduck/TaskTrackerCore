using BLL.Services;
using BLL.Services.Interfaces;
using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using DAL.UnitOfWork;
using DAL.Entities;
using System.Threading.Tasks;
using BLL.DTO;

namespace TaskTrakerCore.UnitTests.Services
{
    public class ProjectServiceTest : TestBaseFixture
    {
        public ProjectServiceTest() :base()
        {
           
        }

        [Fact]
        public void FirstTest()
        {
            var uofMock = new Mock<IUnitOfWork>();
            uofMock.Setup(a => a.ProjectRepository.GetByIdAsync(1))
                .Returns(new Task<Project>(() => new Project { Title = "TestTitle" }));

            IProjectService projectService = new ProjectService(uofMock.Object, Mapper);

            var uof = new UnitOfWork(Context);
            var result = uof.ProjectRepository.GetByIdAsync(1);

           
            var expectedProject = new Project { Title = "TestTitle" };

            Assert.Equal(expectedProject.Title, result.Result.Title);
        }
    }
}
