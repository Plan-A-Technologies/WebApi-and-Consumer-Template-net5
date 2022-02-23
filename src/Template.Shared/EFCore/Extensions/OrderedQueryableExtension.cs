using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Template.Shared.EFCore.Extensions
{
    /// <summary>
    ///     THe Ordered Queryable Extension
    /// </summary>
    public static class OrderedQueryableExtension
    {
        /// <summary>
        ///     Orders the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="comparer">The comparer.</param>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "OrderBy", propertyName, comparer);
        }

        /// <summary>
        ///     Orders the by descending.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="comparer">The comparer.</param>
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "OrderByDescending", propertyName, comparer);
        }

        /// <summary>
        ///     Thens the by.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="comparer">The comparer.</param>
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "ThenBy", propertyName, comparer);
        }

        /// <summary>
        ///     Thens the by descending.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="comparer">The comparer.</param>
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> query, string propertyName, IComparer<object> comparer = null)
        {
            return CallOrderedQueryable(query, "ThenByDescending", propertyName, comparer);
        }

        /// <summary>
        ///     Calls the ordered queryable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query">The query.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="comparer">The comparer.</param>
        public static IOrderedQueryable<T> CallOrderedQueryable<T>(
            this IQueryable<T> query, string methodName, string propertyName,
            IComparer<object> comparer = null)
        {
            var param = Expression.Parameter(typeof(T), "x");

            var body = propertyName.Split('.').Aggregate<string, Expression>(param, Expression.PropertyOrField);

            return comparer != null
                ? (IOrderedQueryable<T>) query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        methodName,
                        new[] { typeof(T), body.Type },
                        query.Expression,
                        Expression.Lambda(body, param),
                        Expression.Constant(comparer)
                    )
                )
                : (IOrderedQueryable<T>) query.Provider.CreateQuery(
                    Expression.Call(
                        typeof(Queryable),
                        methodName,
                        new[] { typeof(T), body.Type },
                        query.Expression,
                        Expression.Lambda(body, param)
                    )
                );
        }
    }
}