using Employees.Core.Interfaces.DatаAccess;
using System;
using System.Linq.Expressions;

namespace Employees.Core.DomainModels
{
    public class EmployeeSpecification : ISpecification<Employee>
    {

        public Expression<Func<Employee, bool>> Criteria { get; private set; }
        public Expression<Func<Employee, object>> OrderByDesc { get; private set; }
        public Expression<Func<Employee, object>> ThenBy { get; private set; }

        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; }

        public void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

        public void ApplyCriteria(Expression<Func<Employee, bool>> criteria)
        {
            Criteria = criteria;
        }

        public void ApplyOrderBy(Expression<Func<Employee, object>> orderByExpression, Expression<Func<Employee, object>> thenBy = null)
        {
            OrderByDesc = orderByExpression;
            ThenBy = thenBy;
        }
    }
}
