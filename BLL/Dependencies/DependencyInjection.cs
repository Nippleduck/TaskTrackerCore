using AutoMapper;
using BLL.JwtAuth;
using BLL.Services;
using BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BLL.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBllConfiguration
            (this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectTaskService, ProjectTaskService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
