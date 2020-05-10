using DAL.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DAL.UnitOfWork;

namespace DAL.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureDalDependencies
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskTrackerContext>(options =>
            options.UseLazyLoadingProxies().
            UseSqlServer(configuration.
            GetConnectionString("TaskTrackerDataBase")));

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
