using DAL.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DAL.UnitOfWork;
using DAL.Entities.IdentityModel;
using Microsoft.AspNetCore.Identity;

namespace DAL.Dependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDalConfiguration
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TaskTrackerContext>(options =>
            options.UseLazyLoadingProxies().
            UseSqlServer(configuration.
            GetConnectionString("TaskTrackerDataBase")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<TaskTrackerContext>();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = true;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
            });

            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();

            return services;
        }
    }
}
