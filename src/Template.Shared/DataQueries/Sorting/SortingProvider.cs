using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using Template.Shared.DataQueries.Sorting.Abstractions;
using Template.Shared.EFCore.Extensions;

namespace Template.Shared.DataQueries.Sorting
{
    /// <inheritdoc/>
    /// <seealso cref="Template.Shared.DataQueries.Sorting.Abstractions.ISortingProvider&lt;T&gt;"/>
    public class SortingProvider<T> : ISortingProvider<T>
    {
        /// <summary>
        ///     Gets the options.
        /// </summary>
        /// <value>
        ///     The options.
        /// </value>
        public ISortingOptions Options { get; protected set; }

        /// <summary>
        ///     Gets the key selectors alias.
        /// </summary>
        /// <value>
        ///     The key selectors alias.
        /// </value>
        public IDictionary<string, Expression<Func<T, object>>> KeySelectorsAlias { get; } = new Dictionary<string, Expression<Func<T, object>>>();

        /// <summary>
        ///     Initializes a new instance of the <see cref="SortingProvider{T}"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public SortingProvider(ISortingOptions options)
        {
            Options = options;
        }

        /// <summary>
        ///     Appends the key selector alias.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public void AppendKeySelectorAlias(string name, Expression<Func<T, object>> value)
        {
            KeySelectorsAlias.Add(name, value);
        }

        /// <inheritdoc/>
        public virtual IQueryable<T> Apply(IQueryable<T> data)
        {
            if (string.IsNullOrEmpty(Options.OrderBy))
            {
                return data;
            }

            IOrderedQueryable<T> dataOrdered = ApplyOrderBy(data);

            if (string.IsNullOrEmpty(Options.ThenBy))
            {
                return dataOrdered;
            }

            dataOrdered = ApplyThenBy(dataOrdered);

            return dataOrdered;
        }

        /// <summary>
        ///     Apply the Order By
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The sorted by data.</returns>
        public virtual IOrderedQueryable<T> ApplyOrderBy(IQueryable<T> data)
        {
            (var key, Expression<Func<T, object>> selector) = KeySelectorsAlias.FirstOrDefault(x =>
                Options.OrderBy.Equals(x.Key, StringComparison.CurrentCultureIgnoreCase));

            if (!string.IsNullOrEmpty(key))
            {
                return Options.Asc ?
                    data.OrderBy(selector) :
                    data.OrderByDescending(selector);
            }

            return Options.Asc ?
                data.OrderBy(Options.OrderBy) :
                data.OrderByDescending(Options.OrderBy);
        }

        /// <summary>
        ///     Apply the Then By
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The sorted by data</returns>
        public virtual IOrderedQueryable<T> ApplyThenBy(IOrderedQueryable<T> data)
        {
            (var key, Expression<Func<T, object>> selector) = KeySelectorsAlias.FirstOrDefault(x =>
                Options.ThenBy.Equals(x.Key, StringComparison.CurrentCultureIgnoreCase));

            if (!string.IsNullOrEmpty(key))
            {
                return Options.ThenByAsc ?
                    data.ThenBy(selector) :
                    data.ThenByDescending(selector);
            }

            return Options.ThenByAsc ?
                data.ThenBy(Options.ThenBy) :
                data.ThenByDescending(Options.ThenBy);
        }
    }
}