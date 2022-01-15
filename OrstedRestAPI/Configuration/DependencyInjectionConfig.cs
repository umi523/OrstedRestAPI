using Microsoft.EntityFrameworkCore;
using OrstedBusiness;
using OrstedData;
using OrstedData.DataContext;

namespace OrstedRestAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(
        this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddDbContext<OrstedDataContext>(opt => opt.UseInMemoryDatabase("OrstedDatabase"));
            services.AddScoped<IEmployeeBusinessService, EmployeeBusinessService>();
            services.AddScoped<IEmployeeDataService, EmployeeDataService>();
            return services;
        }
    }
}