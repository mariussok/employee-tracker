using EmployeeTracker.Repositories;
using EmployeeTracker.Services.Models;
using EmployeeTracker.Services.Parsers;
using System;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task ExecuteAsync(string[] arguments)
        {
            var request = EmployeeArgumentParser.Parse(arguments);

            switch (request.Type)
            {
                case RequestType.SetEmployee:
                    Console.WriteLine(request);

                    await _employeeRepository.AddAsync(request.Id, request.Name, request.Salary);

                    break;
                case RequestType.GetEmployee:
                    var date = request.SimulatedTimeUtc ?? DateTime.UtcNow;

                    Console.WriteLine(request + " " + date);

                    var employees = await _employeeRepository.GetAsync(request.Id, date);

                    foreach (var employee in employees)
                    {
                        Console.WriteLine(employee);
                    }

                    break;
                default:
                    break;
            }

            
        }
    }
}
