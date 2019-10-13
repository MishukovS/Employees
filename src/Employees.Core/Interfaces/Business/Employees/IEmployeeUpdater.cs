using Employees.Core.DomainModels;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Business.Employees
{
    public interface IEmployeeUpdater
    {
        Task UpdateAsync(int id, EmployeeSaveRequest employee);
    }
}
