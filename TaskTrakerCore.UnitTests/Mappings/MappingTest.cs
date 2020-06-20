using AutoMapper;
using BLL.DTO;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace TaskTrakerCore.UnitTests.Mappings
{
    public class MappingTest : IClassFixture<MappingFixture>
    { 
        private readonly IMapper mapper;

        public MappingTest(MappingFixture fixture) =>
            mapper = fixture.Mapper;

        [Fact]
        public void ShouldHaveValidConfig()
        {
            mapper.ConfigurationProvider
                .AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(Project), typeof(ProjectDTO))]
        [InlineData(typeof(ProjectUser), typeof(UserDTO))]
        public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
        {
            var project = new Project { Title = "test" };

            var result = mapper.Map<ProjectDTO>(project);

            var expected = new ProjectDTO { Title = "test" };

            Assert.Equal(expected.Title, result.Title);
        }
    }
}
