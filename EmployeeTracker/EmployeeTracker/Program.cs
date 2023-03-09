using Microsoft.Extensions.DependencyInjection;
using System;
using EmployeeTracker.Configuration;
using Microsoft.Extensions.Configuration;
using EmployeeTracker.Services;
using System.Threading.Tasks;

namespace EmployeeTracker
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            var services = new ServiceCollection();

            var provider = services.AddServiceConfiguration(configuration)
                .BuildServiceProvider();

            var employeeService = provider.GetRequiredService<IEmployeeService>();

            await employeeService.ExecuteAsync(args);

            Console.WriteLine("The End");
        }
    }
}
