using System;

namespace EmployeeTracker.Services.Models
{
    public class EmployeeRequest
    {
        public RequestType Type { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public DateTime? SimulatedTimeUtc { get; set; }
    }
}
