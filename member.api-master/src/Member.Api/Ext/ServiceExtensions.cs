using Member.Domain.Services;
using Member.Infrastructure;
using Member.Infrastructure.Repositories;
using Member.Domain.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Member.Api.Ext
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRoleService, UserRoleService>();

            services.AddScoped<IUserRoleRepository, UserRoleRepository>();


            var configSection = configuration.GetSection("DBSettings");
            var settings = new DBSettings();
            configSection.Bind(settings);

            services.Configure<DBSettings>(configuration.GetSection("DBSettings"));

        }
    }
}
