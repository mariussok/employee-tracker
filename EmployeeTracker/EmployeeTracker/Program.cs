using Microsoft.Extensions.DependencyInjection;
using System;
using EmployeeTracker.Configuration;
using Microsoft.Extensions.Configuration;

namespace EmployeeTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();


            var services = new ServiceCollection();

            services.AddServiceConfiguration(configuration);

            var provider = services.BuildServiceProvider();


            Console.WriteLine("Hello World!");
        }
    }
}
