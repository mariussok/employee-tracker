using EmployeeTracker.Configuration;
using EmployeeTracker.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace EmployeeTracker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started");

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            var provider = services.AddServiceConfiguration(configuration)
                .BuildServiceProvider();

            var employeeService = provider.GetRequiredService<IEmployeeService>();

            await employeeService.ExecuteAsync(args);

            Console.WriteLine("Application Stopped");
        }
    }
}
