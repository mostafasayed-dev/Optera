using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Optera.Shared.Extensions.Querying
{
    public static class QueryableSearchExtensions
    {
        public static IQueryable<T> ApplySearch<T>(
                this IQueryable<T> query,
                string? searchKey,
                params Expression<Func<T, string?>>[] properties)
        {
            if (string.IsNullOrWhiteSpace(searchKey) || properties.Length == 0)
                return query;

            var parameter = Expression.Parameter(typeof(T), "x");
            Expression? body = null;

            foreach (var property in properties)
            {
                // x.Property
                var invoked = Expression.Invoke(property, parameter);

                // EF.Functions.Like(x.Property, "%search%")
                var like = Expression.Call(
                    typeof(DbFunctionsExtensions),
                    nameof(DbFunctionsExtensions.Like),
                    Type.EmptyTypes,
                    Expression.Property(null, typeof(EF), nameof(EF.Functions)),
                    invoked,
                    Expression.Constant($"%{searchKey}%")
                );

                body = body == null
                    ? like
                    : Expression.OrElse(body, like);
            }

            var predicate = Expression.Lambda<Func<T, bool>>(body!, parameter);
            return query.Where(predicate);
        }
    }
}
