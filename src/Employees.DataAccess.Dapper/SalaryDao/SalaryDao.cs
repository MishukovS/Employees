using Employees.Core.DomainModels;
using Employees.Core.Interfaces.DatаAccess;
using System.Threading.Tasks;

namespace Employees.DataAccess.Dapper.SalaryDao
{
    public class SalaryDao : ISalaryDao
    {
        private readonly ISqlDbExecutor sqlDbExecutor;

        public SalaryDao(ISqlDbExecutor sqlDbExecutor)
        {
            this.sqlDbExecutor = sqlDbExecutor;
        }

        public Task<Employee> GetEmployeeWithMaxSalaryAsync()
        {
            var sql = SqlScripts.GetEmployeeWithMaxSalary;
            return sqlDbExecutor.FirstOrDefaultAsync<Employee>(sql);
        }

        public Task<decimal> GetSalarySumAsync()
        {
            var sql = SqlScripts.GetSalarySum;
            return sqlDbExecutor.FirstOrDefaultAsync<decimal>(sql);
        }
    }
}
