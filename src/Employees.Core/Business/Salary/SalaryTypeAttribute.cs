using Employees.Core.DomainModels;
using System;

namespace Employees.Core.Business.Salary
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    internal class SalaryTypeAttribute : Attribute
    {
        public SalaryTypeAttribute(SalaryType salaryType)
        {
            SalaryType = salaryType;
        }

        public SalaryType SalaryType { get; }
    }
}
