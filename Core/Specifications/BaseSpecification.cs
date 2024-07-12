using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    // A base specification class for specifying criteria, includes, and ordering for queries
    public class BaseSpecification<T> : ISpecification<T>
    {
        // Default constructor
        public BaseSpecification()
        {
        }

        // Constructor with criteria expression
        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        // Criteria expression for filtering
        public Expression<Func<T, bool>> Criteria { get; }

        // List of include expressions for related entities
        public List<Expression<Func<T, object>>> Includes { get; } =
            new List<Expression<Func<T, object>>>();

        // Expression for ordering
        public Expression<Func<T, object>> OrderBy { get; private set; }

        // Expression for descending ordering
        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Take { get; private set; }

        public int Skip { get; private set; }

        public bool IsPagingEnabled { get; private set; }

        // Method to add an include expression for related entities
        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        // Method to set the order by expression
        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        // Method to set the order by descending expression
        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
        {
            OrderByDescending = orderByDescExpression;
        }

        protected void ApplyPaging(int skip, int take)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
        }

    }
}
