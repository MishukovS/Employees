namespace Employees.Core.DomainModels
{
    public class SalaryModel
    {
        public SalaryType Type { get; set; }

        public decimal Rate { get; set; }

        public bool IncludeTax { get; set; }
    }
}
