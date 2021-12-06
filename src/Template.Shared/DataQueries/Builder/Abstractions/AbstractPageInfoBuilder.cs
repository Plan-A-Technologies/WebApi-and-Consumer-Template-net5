using System.Linq;

using Template.Shared.DataQueries.Filtering;
using Template.Shared.DataQueries.Pagination.Options;
using Template.Shared.DataQueries.Sorting.Abstractions;

namespace Template.Shared.DataQueries.Builder.Abstractions
{
    /// <summary>
    ///     The Abstract class of the Page Info Builder.
    /// </summary>
    /// <typeparam name="T">The type of Data</typeparam>
    public abstract class AbstractPageInfoBuilder<T>
    {
        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public IQueryable<T> Data { get; protected set; }

        /// <summary>
        ///     Gets or sets the paging offset options.
        /// </summary>
        /// <value>
        ///     The paging offset options.
        /// </value>
        public IPagingOffsetOptions PagingOffsetOptions { get; protected set; }

        /// <summary>
        ///     Gets or sets the default top.
        /// </summary>
        /// <value>
        ///     The default top.
        /// </value>
        public int DefaultPagingOffsetTop { get; protected set; }

        /// <summary>
        ///     Gets or sets the sorting provider.
        /// </summary>
        /// <value>
        ///     The sorting provider.
        /// </value>
        public ISortingProvider<T> SortingProvider { get; protected set; }

        /// <summary>
        ///     Gets or sets the filtering provider.
        /// </summary>
        /// <value>
        ///     The filtering provider.
        /// </value>
        public IFilteringProvider<T> FilteringProvider { get; protected set; }

        /// <summary>
        ///     Applies the providers.
        /// </summary>
        protected virtual void ApplyProviders()
        {
            if (FilteringProvider != null)
            {
                Data = FilteringProvider.Apply(Data);
            }

            if (SortingProvider != null)
            {
                Data = SortingProvider.Apply(Data);
            }
        }

        /// <summary>
        ///     Normalizes paging offset options.
        /// </summary>
        /// <param name="totalRowCount">The total row count.</param>
        protected virtual void NormalizePagingOffsetOptions(int totalRowCount)
        {
            if (PagingOffsetOptions.Skip >= totalRowCount)
            {
                PagingOffsetOptions.Skip = PagingOffsetOptions.Skip - totalRowCount;
            }

            if (PagingOffsetOptions.Top == 0)
            {
                PagingOffsetOptions.Top = DefaultPagingOffsetTop;
            }
        }
    }
}