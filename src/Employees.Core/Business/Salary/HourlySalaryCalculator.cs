using Employees.Core.DomainModels;
using Employees.Core.Interfaces.Business.Salary;

namespace Employees.Core.Business.Salary
{
    [SalaryType(SalaryType.Hourly)]
    public sealed class HourlySalaryCalculator : ISalaryCalculator
    {
        private const decimal _daysInMonth = 20.8M;
        private const int _hoursInDay = 8;

        public decimal Calculate(SalaryModel model)
        {
            var salary = model.Rate * _hoursInDay * _daysInMonth;

            return model.IncludeTax ?
                salary :
                TaxCalculator.GetSumIncludeTax(salary);
        }
    }
}
