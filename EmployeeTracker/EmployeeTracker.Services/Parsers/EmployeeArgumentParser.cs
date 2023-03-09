using EmployeeTracker.Services.Models;
using System;
using System.Linq;

namespace EmployeeTracker.Services.Parsers
{
    public static class EmployeeArgumentParser
    {
        public static EmployeeRequest Parse(string[] arguments)
        {
            var parsedRequest = new EmployeeRequest();

            if (arguments is null || !arguments.Any()) 
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            parsedRequest.Type = ParseRequestType(arguments[0]);

            for (var i = 1; i < arguments.Length; i++)
            {
                switch (arguments[i])
                {
                    case "--employeeId":
                        i++;
                        parsedRequest.Id = int.Parse(arguments[i]);
                        break;
                    case "--employeeName":
                        i++;
                        parsedRequest.Name = arguments[i];
                        break;
                    case "--employeeSalary":
                        i++;
                        parsedRequest.Salary = int.Parse(arguments[i]); ;
                        break;
                    case "--simulatedTimeUtc":
                        i++;
                        parsedRequest.SimulatedTimeUtc = DateTime.Parse(arguments[i]);
                        break;
                }
            }

            return parsedRequest;
        }

        private static RequestType ParseRequestType(string type)
        {
            switch (type)
            {
                case "set-employee":
                    return RequestType.SetEmployee;
                case "get-employee":
                    return RequestType.GetEmployee;
                default:
                    throw new ArgumentException($"Unable to resolve request type: {type}");
            }
        }
    }
}
