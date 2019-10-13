using Employees.Core.DomainModels;

namespace Employees.Core.Interfaces.Business.Salary
{
    public interface ISalaryCalculatorFactory
    {
        ISalaryCalculator GetInstance(SalaryType salaryType);
    }
}
