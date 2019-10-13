using Employees.Core.DomainModels;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Business.Empoyees
{
    public interface IEmployeeCreator
    {
        Task CreateAsync(EmployeeSaveRequest employee);        
    }
}
