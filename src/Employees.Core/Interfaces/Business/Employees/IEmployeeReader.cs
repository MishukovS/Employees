using Employees.Core.DomainModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Business.Empoyees
{
    public interface IEmployeeReader
    {       

        Task<IReadOnlyList<Employee>> GetListAsync(int pageSize, int pageIndex);

        Task<Employee> GetByIdAsync(int id);

        Task<Employee> GetByNameAsync(string name);
    }
}
