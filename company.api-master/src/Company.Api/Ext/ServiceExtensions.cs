using Company.Domain.Repositories;
using Company.Domain.Repositories.Define;
using Company.Domain.Service;
using Company.Domain.Service.Define;
using Company.Infrastructure;
using Company.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company.Api.Ext
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepositoryWrapper(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<IStaffHourService, StaffHourService>();

            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IStaffHourRepository, StaffHourRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IBranchRepository, BranchRepository>();


            var configSection = configuration.GetSection("DBSettings");
            var settings = new DBSettings();
            configSection.Bind(settings);

            services.Configure<DBSettings>(configuration.GetSection("DBSettings"));

        }
    }
}
