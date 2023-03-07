using EmployeeTracker.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeTracker.Configuration
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServiceConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("ConnectionString"))
                        .EnableSensitiveDataLogging()
                , ServiceLifetime.Transient);

            return services;
        }
    }
}