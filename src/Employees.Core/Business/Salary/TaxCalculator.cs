namespace Employees.Core.Business.Salary
{
    public static class TaxCalculator
    {
        public const decimal TAX_RATE_IN_PERCENT = 13M;

        public static decimal GetSumIncludeTax(decimal value)
        {
            return value * (100 + TAX_RATE_IN_PERCENT) / 100;
        }
    }
}
