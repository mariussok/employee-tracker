using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTracker.Repositories.Entities
{
    public class Employee
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("employeeid")]
        public int EmployeeId { get; set; }

        [Column("employeename")]
        public string EmployeeName { get; set; }

        [Column("employeesalary")]
        public int EmployeeSalary { get; set; }

        [Column("existencestartutc")]
        public DateTime ExistenceStartUtc { get; set; }

        [Column("existenceendutc")]
        public DateTime? ExistenceEndUtc { get; set; }

        public override string ToString()
        {
            return $"{nameof(EmployeeId)}: {EmployeeId}; {nameof(EmployeeName)}: {EmployeeName}; {nameof(EmployeeSalary)}: {EmployeeSalary}; {nameof(ExistenceStartUtc)}: {ExistenceStartUtc}; {nameof(ExistenceEndUtc)}: {ExistenceEndUtc}";
        }
    }
}
