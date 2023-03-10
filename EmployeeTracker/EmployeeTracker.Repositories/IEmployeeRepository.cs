using EmployeeTracker.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeTracker.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAsync(int id, DateTime date);
        Task AddAsync(int id, string name, int salary);
    }
}
