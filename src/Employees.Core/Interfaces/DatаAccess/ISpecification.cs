using System;
using System.Linq.Expressions;

namespace Employees.Core.Interfaces.DatаAccess
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }
        Expression<Func<T, object>> OrderByDesc { get; }
        Expression<Func<T, object>> ThenBy { get; }

        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
    }
}
