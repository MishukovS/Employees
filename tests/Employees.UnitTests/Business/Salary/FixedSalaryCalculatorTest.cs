using AutoFixture;
using Employees.Core.Business.Salary;
using Employees.Core.DomainModels;
using FluentAssertions;
using NUnit.Framework;

namespace Employees.UnitTests.Business.Salary
{
    [TestFixture]
    public class FixedSalaryCalculatorTest
    {
        private readonly FixedSalaryCalculator _calculator = new FixedSalaryCalculator();
        private readonly Fixture _fixture = new Fixture();

        [Test]
        public void Calculate_IncludeTax_SalarySumShouldBeEqualRate()
        {
            var model = new SalaryModel
            {
                IncludeTax = true,
                Rate = _fixture.Create<decimal>()
            };
            var salarySum = _calculator.Calculate(model);

            salarySum.Should().Be(model.Rate);
        }

        [Test]
        public void Calculate_NotIncludeTax_SalarySumShouldBeGreaterRate()
        {
            var model = new SalaryModel
            {
                IncludeTax = false,
                Rate = _fixture.Create<decimal>()
            };
            var salarySum = _calculator.Calculate(model);

            salarySum.Should().BeGreaterThan(model.Rate);
        }
    }
}