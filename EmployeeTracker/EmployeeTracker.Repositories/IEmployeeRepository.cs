using EmployeeTracker.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EmployeeTracker.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetAsync(int id);
        Task AddAsync(int id, string name, int salary);
    }
}
