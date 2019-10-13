using System.Threading.Tasks;

namespace Employees.Core.Interfaces.Business.Employees
{
    public interface IEmployeeRemover
    {
        Task DeleteAsync(int id);
    }
}
