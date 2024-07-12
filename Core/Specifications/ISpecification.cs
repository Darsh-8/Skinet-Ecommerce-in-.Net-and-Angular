using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    // Interface for defining specifications for queries
    public interface ISpecification<T>
    {
        // Criteria expression for filtering
        Expression<Func<T, bool>> Criteria { get; }

        // List of include expressions for related entities
        List<Expression<Func<T, object>>> Includes { get; }

        // Expression for ordering
        Expression<Func<T, object>> OrderBy { get; }

        // Expression for descending ordering
        Expression<Func<T, object>> OrderByDescending { get; }

        int Take { get; }

        int Skip { get; }

        bool IsPagingEnabled { get; }
    }
}
