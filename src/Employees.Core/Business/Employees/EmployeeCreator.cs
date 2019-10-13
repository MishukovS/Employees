using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Empoyees;
using Employees.Core.Interfaces.Business.Salary;
using Employees.Core.Interfaces.DatаAccess;
using System.Threading.Tasks;

namespace Employees.Core.Business.Employees
{
    public class EmployeeCreator : IEmployeeCreator
    {
        private readonly IBaseRepository<Employee> _repository;
        private readonly ISalaryCalculatorFactory _salaryCalculatorFactory;

        public EmployeeCreator(
            IBaseRepository<Employee> repository,
            ISalaryCalculatorFactory salaryCalculatorFactory)
        {
            _repository = repository;
            _salaryCalculatorFactory = salaryCalculatorFactory;
        }

        public async Task CreateAsync(EmployeeSaveRequest request)
        {
            var calculator = _salaryCalculatorFactory.GetInstance(request.SalaryModel.Type);
            var salarySum = calculator.Calculate(request.SalaryModel);
            var employee = new Employee
            {
                Name = request.Name,          
                SalarySum = salarySum
            };

            await _repository.AddAsync(employee);
        }
    }
}
