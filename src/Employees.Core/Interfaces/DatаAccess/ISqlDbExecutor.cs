using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.DatаAccess
{
    public interface ISqlDbExecutor
    {
        Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object queryParams = null);

        Task<T> FirstOrDefaultAsync<T>(string sql, object queryParams = null);
    }
}
