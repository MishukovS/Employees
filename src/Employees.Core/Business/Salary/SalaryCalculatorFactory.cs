using Employees.Core.DomainModels;
using Employees.Core.Exceptions;
using Employees.Core.Interfaces.Business.Salary;
using System.Collections.Generic;
using System.Linq;

namespace Employees.Core.Business.Salary
{
    public class SalaryCalculatorFactory : ISalaryCalculatorFactory
    {
        private readonly Dictionary<SalaryType, ISalaryCalculator> _calculators =
          new Dictionary<SalaryType, ISalaryCalculator>();

        public SalaryCalculatorFactory(IEnumerable<ISalaryCalculator> calculators)
        {
            foreach (var calculator in calculators)
            {
                var attributeType = typeof(SalaryTypeAttribute);
                var attribute = calculator.GetType().GetCustomAttributes(attributeType, false)
                    .Cast<SalaryTypeAttribute>()
                    .FirstOrDefault();

                if (attribute == null)
                {
                    continue;
                }
                if (!_calculators.ContainsKey(attribute.SalaryType))
                {
                    _calculators.Add(attribute.SalaryType, calculator);
                }
            }
        }

        public ISalaryCalculator GetInstance(SalaryType salaryType)
        {
            if (_calculators.ContainsKey(salaryType))
            {
                return _calculators[salaryType];
            }

            throw new UnknownSalaryTypeExeption();
        }
    }
}
