using System.Linq;

namespace Template.Shared.DataQueries.Sorting.Abstractions
{
    /// <summary>
    ///     The sorting provider.
    /// </summary>
    /// <typeparam name="T">The type of the data</typeparam>
    public interface ISortingProvider<T>
    {
        /// <summary>
        ///     Applies sorting on the specified data
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The sorted data.</returns>
        public IQueryable<T> Apply(IQueryable<T> data);
    }
}