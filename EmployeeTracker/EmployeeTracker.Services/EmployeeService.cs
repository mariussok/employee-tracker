using EmployeeTracker.Repositories;
using EmployeeTracker.Repositories.Entities;
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
                    await _employeeRepository.AddAsync(request.Id, request.Name, request.Salary);
                    break;
                case RequestType.GetEmployee:
                    var employee = await _employeeRepository.GetAsync(request.Id);

                    Console.WriteLine($"{employee.EmployeeId} {employee.EmployeeName} {employee.EmployeeSalary}");
                    break;
                default:
                    break;
            }

            
        }
    }
}
