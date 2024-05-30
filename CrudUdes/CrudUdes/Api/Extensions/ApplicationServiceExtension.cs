using CrudUdes.Api.Services;
using CrudUdes.Application.UnitOfWork;
using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CrudUdes.Api.Extensions
{
    public static class ApplicationServiceExtension
    {

        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin();
                });
            });

        }

        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddScoped<IUserService, UserService>();


        }
    }
}
