using DAL.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskTrackerContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("")));

            return services;
        }
    }
}
