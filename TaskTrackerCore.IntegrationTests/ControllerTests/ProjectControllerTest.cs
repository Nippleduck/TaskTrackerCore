using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerCore.IntegrationTests.TestConfigurations;
using Xunit;

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

            Assert.Equal("", data);
        }
    }
}
