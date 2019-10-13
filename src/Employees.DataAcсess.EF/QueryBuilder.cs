using Employees.Core.Interfaces.DatаAccess;
using System.Linq;

namespace Employees.DataAcсess.EF
{
    internal class QueryBuilder<T>
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            if (spec.OrderByDesc != null)
            {
                query =  query.OrderByDescending(spec.OrderByDesc).ThenBy(spec.ThenBy);
            }

            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip)
                             .Take(spec.Take);
            }

            return query;
        }
    }
}
