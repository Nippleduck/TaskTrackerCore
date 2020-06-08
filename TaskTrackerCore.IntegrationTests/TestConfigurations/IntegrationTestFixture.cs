using API;
using BLL.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskTrackerCore.IntegrationTests.TestConfigurations
{
    public class IntegrationTestFixture : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureTestServices(servicesConfiguration => 
            {
                servicesConfiguration.AddScoped<IProjectService>();
                servicesConfiguration.AddScoped<IUserService>();
            });
        }
    }
}
