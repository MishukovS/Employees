using System.Threading.Tasks;
using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Salary;
using Employees.Core.Interfaces.DatаAccess;

namespace Employees.Core.Business.Salary
{
    public class SalaryReader : ISalaryReader
    {
        private readonly ISalaryDao _salaryDao;

        public SalaryReader(ISalaryDao salaryDao)
        {
            _salaryDao = salaryDao;
        }

        public Task<Employee> GetEmployeeWithMaxSalaryAsync()
        {
            return _salaryDao.GetEmployeeWithMaxSalaryAsync();
        }

        public Task<decimal> GetSalarySumAsync()
        {
            return _salaryDao.GetSalarySumAsync();
        }
    }
}
