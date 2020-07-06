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
        public void Calculate_WhenIncludeTax_ThenSalarySumShouldBeEqualRate()
        {
            // Arrange
            var model = new SalaryModel
            {
                IncludeTax = true,
                Rate = _fixture.Create<decimal>()
            };

            // Act
            var salarySum = _calculator.Calculate(model);

            // Assert
            salarySum.Should().Be(model.Rate);
        }

        [Test]
        public void Calculate_WhenNotIncludeTax_ThenSalarySumShouldBeGreaterRate()
        {
            // Arrange
            var model = new SalaryModel
            {
                IncludeTax = false,
                Rate = _fixture.Create<decimal>()
            };

            // Act
            var salarySum = _calculator.Calculate(model);

            // Assert
            salarySum.Should().BeGreaterThan(model.Rate);
        }
    }
}