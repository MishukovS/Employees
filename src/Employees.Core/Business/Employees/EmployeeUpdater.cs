using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Employees;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.Business.Salary;
using Employees.Core.Interfaces.DatаAccess;
using System.Threading.Tasks;

namespace Employees.Core.Business.Employees
{
    public class EmployeeUpdater : IEmployeeUpdater
    {
        private readonly IBaseRepository<Employee> _repository;
        private readonly IEmployeeReader _reader;
        private readonly ISalaryCalculatorFactory _salaryCalculatorFactory;

        public EmployeeUpdater(
            IBaseRepository<Employee> repository,
            IEmployeeReader reader,
            ISalaryCalculatorFactory salaryCalculatorFactory)
        {
            _repository = repository;
            _reader = reader;
            _salaryCalculatorFactory = salaryCalculatorFactory;
        }

        public async Task UpdateAsync(int id, EmployeeSaveRequest request)
        {
            var calculator = _salaryCalculatorFactory.GetInstance(request.SalaryModel.Type);
            var salarySum = calculator.Calculate(request.SalaryModel);

            var employee = await _reader.GetByIdAsync(id);
            employee.Name = request.Name;      
            employee.SalarySum = salarySum;

            await _repository.UpdateAsync(employee);
        }
    }
}
