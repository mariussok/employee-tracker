using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeTracker.Repositories.Entities
{
    public class Employee
    {
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
    }
}
