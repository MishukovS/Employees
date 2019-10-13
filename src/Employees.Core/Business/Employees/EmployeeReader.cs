using Employees.Core.DomainModels;
using Employees.Core.Exceptions;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.DatаAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Core.Business.Employees
{
    public class EmployeeReader : IEmployeeReader
    {

        private readonly IBaseRepository<Employee> _repository;

        public EmployeeReader(IBaseRepository<Employee> repository)
        {
            _repository = repository;
        }

        public Task<IReadOnlyList<Employee>> GetListAsync(int pageSize, int pageIndex)
        {
            var spec = new EmployeeSpecification();
            spec.ApplyPaging(pageSize * pageIndex, pageSize);
            spec.ApplyOrderBy(x => x.SalarySum, x => x.Name);

            return _repository.GetBySpecificationAsync(spec);
        }

        public async Task<Employee> GetByNameAsync(string name)
        {
            var spec = new EmployeeSpecification();            
            spec.ApplyCriteria(x => x.Name == name);

            var employees = await _repository.GetBySpecificationAsync(spec);

            if (employees.Count == 0)
            {
                throw new EmployeeNotFoundException(name);
            }
            return employees.First();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            var spec = new EmployeeSpecification();
            spec.ApplyCriteria(x => x.Id == id);

            var employees = await _repository.GetBySpecificationAsync(spec);

            if (employees.Count == 0)
            {
                throw new EmployeeNotFoundException(id);
            }
            return employees.First();
        }
    }
}
