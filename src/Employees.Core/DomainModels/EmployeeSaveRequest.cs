namespace Employees.Core.DomainModels
{
    public class EmployeeSaveRequest
    {
        public string Name { get; set; }

        public SalaryModel SalaryModel { get; set; }

    }
}
