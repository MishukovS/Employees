using AutoFixture;
using Employees.Core.Business.Salary;
using Employees.Core.DomainModels;
using FluentAssertions;
using NUnit.Framework;

namespace Employees.UnitTests.Business.Salary
{
    [TestFixture]
    public class HourlySalaryCalculatorTest
    {
        private readonly HourlySalaryCalculator _calculator = new HourlySalaryCalculator();
        private readonly Fixture _fixture = new Fixture();

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void Calculate_RateEqualZero_SalaryEqual(bool includeTax)
        {
            var model = new SalaryModel
            {
                IncludeTax = includeTax,
                Rate = 0
            };

            var salary = _calculator.Calculate(model);

            salary.Should().Be(model.Rate);
        }

        [Test]
        [TestCase(false)]
        [TestCase(true)]
        public void Calculate_RateGreaterZero_SalaryGreaterRate(bool includeTax)
        {
            var model = new SalaryModel
            {
                IncludeTax = includeTax,
                Rate = _fixture.Create<decimal>()
            };
            var salary = _calculator.Calculate(model);

            salary.Should().BeGreaterThan(model.Rate);
        }
    }
}
