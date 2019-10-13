using Employees.Core.Interfaces.Infrastracture;

namespace Employees.Core.Infrastrature
{
    public class Settings : ISettings
    {
        public string GetConnectionString()
        {
            return "Server=(localdb)\\mssqllocaldb;Database=employeeMain;Trusted_Connection=True;";
        }
    }
}
