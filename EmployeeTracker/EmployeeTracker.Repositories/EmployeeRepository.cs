using EmployeeTracker.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
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

        public async Task<List<Employee>> GetAsync(int id, DateTime date)
        {
            var empployees = await _dbContext.Employees
                .AsNoTracking()
                .Where(e => e.EmployeeId == id && e.ExistenceStartUtc < date)
                .OrderByDescending(e => e.ExistenceStartUtc)
                .ToListAsync();

            return empployees;
        }

        public async Task AddAsync(int id, string name, int salary)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == id && !e.ExistenceEndUtc.HasValue);

            if (employee != null)
            {
                employee.ExistenceEndUtc = DateTime.UtcNow;
            }

            var newEntry = new Employee
            {
                EmployeeId = id,
                EmployeeName = name,
                EmployeeSalary = salary,
                ExistenceStartUtc = DateTime.UtcNow,
            };

            _dbContext.Employees.Add(newEntry);

            await _dbContext.SaveChangesAsync();
        }
    }
}
