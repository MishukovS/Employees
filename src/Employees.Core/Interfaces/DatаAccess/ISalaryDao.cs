using Employees.Core.DomainModels;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.DatаAccess
{
    public interface ISalaryDao
    {
        Task<decimal> GetSalarySumAsync();

        Task<Employee> GetEmployeeWithMaxSalaryAsync();
    }
}
