using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Salary;

namespace Employees.Core.Business.Salary
{
    [SalaryType(SalaryType.Fixed)]
    public sealed class FixedSalaryCalculator : ISalaryCalculator
    {
        public decimal Calculate(SalaryModel model)
        {
            return model.IncludeTax ?
                model.Rate :
                TaxCalculator.GetSumIncludeTax(model.Rate);
        }
    }
}
