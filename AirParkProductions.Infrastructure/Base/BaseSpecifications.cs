using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace AirParkProductions.Infrastructure.Base
{
    public class BaseSpecifications<T> : IBaseSpecifications<T>
    {
        public BaseSpecifications() { }

        public BaseSpecifications(Expression<Func<T, bool>> filterCondition)
        {
            FilterCondition = filterCondition;
        }

        public Expression<Func<T, bool>> FilterCondition { get; private set; }
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public List<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes { get; } = new();

        public Expression<Func<T, object>> GroupBy { get; private set; }

        public void AddInclude(Func<IQueryable<T>, IIncludableQueryable<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void ApplyOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void ApplyOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected void SetFilterCondition(Expression<Func<T, bool>> filterExpression)
        {
            FilterCondition = filterExpression;
        }

        protected void ApplyGroupBy(Expression<Func<T, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }
    }
}
