using EmployeeTracker.Services.Models;
using EmployeeTracker.Services.Parsers;
using NUnit.Framework;
using System;

namespace EmployeeTracker.Unit.Tests
{
    public class EmployeeArgumentParserTests
    {
        [Test]
        public void Parse_ProvidedSetEmployeeArguments_ReturnParsedRequest()
        {
            var arguments = new[] { "set-employee", "--employeeId", "200", "--employeeName", "John", "--employeeSalary", "333" };

            var actualResult = EmployeeArgumentParser.Parse(arguments);
            
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(RequestType.SetEmployee, actualResult.Type);
            Assert.AreEqual(200, actualResult.Id);
            Assert.AreEqual(333, actualResult.Salary);
            Assert.AreEqual("John", actualResult.Name);
        }

        [Test]
        public void Parse_ProvidedGetEmployeeArguments_ReturnParsedRequest()
        {
            var dateTime = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss");
            var arguments = new[] { "get-employee", "--employeeId", "123", "--simulatedTimeUtc", $"{dateTime}", };

            var actualResult = EmployeeArgumentParser.Parse(arguments);

            Assert.IsNotNull(actualResult);
            Assert.AreEqual(RequestType.GetEmployee, actualResult.Type);
            Assert.AreEqual(123, actualResult.Id);
            Assert.AreEqual(dateTime, actualResult.SimulatedTimeUtc.Value.ToString("yyyy-MM-ddTHH:mm:ss"));
        }
    }
}