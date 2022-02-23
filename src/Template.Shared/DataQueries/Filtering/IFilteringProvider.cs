using System.Linq;

namespace Template.Shared.DataQueries.Filtering
{
    /// <summary>
    ///     The Filtering Provider.
    /// </summary>
    /// <typeparam name="T">The type of the data</typeparam>
    public interface IFilteringProvider<T>
    {
        /// <summary>
        ///     Applies filters on the specified data
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>The filtered data.</returns>
        public IQueryable<T> Apply(IQueryable<T> data);
    }
}