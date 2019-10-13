using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Employees;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.DatаAccess;
using System.Threading.Tasks;

namespace Employees.Core.Business.Employees
{
    public class EmployeeRemover : IEmployeeRemover
    {
        private readonly IBaseRepository<Employee> _repository;
        private readonly IEmployeeReader _reader;

        public EmployeeRemover(IBaseRepository<Employee> repository, IEmployeeReader reader)
        {
            _repository = repository;
            _reader = reader;
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await _reader.GetByIdAsync(id);
            await _repository.DeleteAsync(employee);
        }
    }
}
