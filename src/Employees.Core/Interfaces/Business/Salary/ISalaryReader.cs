using Employees.Core.DomainModels;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Business.Salary
{
    public interface ISalaryReader
    {
        Task<decimal> GetSalarySumAsync();

        Task<Employee> GetEmployeeWithMaxSalaryAsync();
    }
}
