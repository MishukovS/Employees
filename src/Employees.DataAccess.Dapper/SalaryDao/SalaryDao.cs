using Employees.Core.DomainModels;
using Employees.Core.Interfaces.DatаAccess;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Employees.DataAccess.Dapper.SalaryDao
{
    public class SalaryDao : ISalaryDao
    {
        private readonly ISqlDbExecutor sqlDbExecutor;

        public SalaryDao(ISqlDbExecutor sqlDbExecutor, ILogger<SalaryDao> logger)
        {
            this.sqlDbExecutor = sqlDbExecutor;          
        }

        public Task<Employee> GetEmployeeWithMaxSalaryAsync()
        {
            var sql = @"select
                        e.Id,
	                    e.Name,
	                    e.SalarySum
                        from    dbo.Employee as e
                            inner join
                                (select max(SalarySum) as MaxSalarySum from dbo.Employee) as m on
                                e.SalarySum = m.MaxSalarySum;";
           
            return sqlDbExecutor.FirstOrDefaultAsync<Employee>(sql);
        }

        public Task<decimal> GetSalarySumAsync()
        {
            var sql = @"select sum(e.SalarySum) as TotalSalarySum from dbo.Employee as e;";
            return sqlDbExecutor.FirstOrDefaultAsync<decimal>(sql);
        }
    }
}
