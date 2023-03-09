using EmployeeTracker.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTracker.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Employee> GetAsync(int id)
        {
            var empployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id);

            return empployee;
        }

        public async Task AddAsync(int id, string name, int salary)
        {
            var currentRecords = await _dbContext.Employees.Where(e => e.EmployeeId == id && e.ExistenceEndUtc == null).ToListAsync();

            foreach (var record in currentRecords)
            {
                record.ExistenceEndUtc = DateTime.UtcNow;
            }

            var emplyee = new Employee
            {
                EmployeeId = id,
                EmployeeName = name,
                EmployeeSalary = salary,
                ExistenceStartUtc = DateTime.UtcNow,
            };

            await _dbContext.Employees.AddAsync(emplyee);

            await _dbContext.SaveChangesAsync();
        }
    }
}
