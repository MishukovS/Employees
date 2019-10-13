using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employees.Core.Interfaces.DatаAccess
{
    public interface IBaseRepository<T>
    {
        Task<IReadOnlyList<T>> GetBySpecificationAsync(ISpecification<T> spec);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}
