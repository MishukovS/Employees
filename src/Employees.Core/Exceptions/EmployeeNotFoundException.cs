using System;

namespace Employees.Core.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException(string employeeName)
        {
            EmployeeName = employeeName;
        }

        public EmployeeNotFoundException(int id)
        {
            EmployeeId = id;
        }

        public override string ToString()
        {
            if (EmployeeId > 0)
            {
                return $"Employee with Id {EmployeeId} not found";
            }

            return $"Employee with Name {EmployeeName} not found";
        }

        public string EmployeeName { get; private set; }

        public int EmployeeId { get; private set; }
    }
}
