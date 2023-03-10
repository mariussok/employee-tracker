using System.Threading.Tasks;

namespace EmployeeTracker.Services
{
    public interface IEmployeeService
    {
        Task ExecuteAsync(string[] arguments);
    }
}
