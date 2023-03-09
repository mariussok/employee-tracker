using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public interface IEmployeeService
    {
        Task ExecuteAsync(string[] arguments);
    }
}
