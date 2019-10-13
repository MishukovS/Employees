using Employees.Core.DomainModels;

namespace Employees.Core.Interfaces.Business.Salary
{
    public interface ISalaryCalculator
    {
        decimal Calculate(SalaryModel model);
    }

}
