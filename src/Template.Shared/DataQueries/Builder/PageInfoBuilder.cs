using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using Template.Shared.DataQueries.Builder.Abstractions;
using Template.Shared.DataQueries.Filtering;
using Template.Shared.DataQueries.Pagination;
using Template.Shared.DataQueries.Pagination.Options;
using Template.Shared.DataQueries.Sorting.Abstractions;

namespace Template.Shared.DataQueries.Builder
{
    /// <summary>
    ///     Page info builder.
    /// </summary>
    /// <seealso cref="AbstractPageInfoBuilder{T}"/>
    /// <typeparam name="TSource">The source type.</typeparam>
    public class PageInfoBuilder<TSource> : AbstractPageInfoBuilder<TSource>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PageInfoBuilder{TSource}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="options">The options.</param>
        /// <param name="defaultPagingOffsetTop">The default paging offset top.</param>
        public PageInfoBuilder(IQueryable<TSource> data, IPagingOffsetOptions options, int defaultPagingOffsetTop = 10)
        {
            Data = data;
            PagingOffsetOptions = options;
            DefaultPagingOffsetTop = defaultPagingOffsetTop;
        }

        /// <summary>
        ///     Adds the selector.
        /// </summary>
        /// <typeparam name="TDestinition">The type of the data destinition.</typeparam>
        /// <param name="selector">The selector to map property of Source to Destinition.</param>
        /// <returns>The Selectable Page Info Builder.</returns>
        public SelectablePageInfoBuilder<TSource, TDestinition> AddSelector<TDestinition>(Expression<Func<TSource, TDestinition>> selector)
        {
            return new SelectablePageInfoBuilder<TSource, TDestinition>(this, selector);
        }

        /// <summary>
        ///     Adds the filtering provider.
        /// </summary>
        /// <param name="filteringProvider">The filtering provider.</param>
        /// <returns>The Page Info Builder.</returns>
        public PageInfoBuilder<TSource> AddFilteringProvider(IFilteringProvider<TSource> filteringProvider)
        {
            FilteringProvider = filteringProvider;

            return this;
        }

        /// <summary>
        ///     Adds the sorting provider.
        /// </summary>
        /// <param name="sortingProvider">The sorting provider.</param>
        /// <returns>The Page Info Builder.</returns>
        public PageInfoBuilder<TSource> AddSortingProvider(ISortingProvider<TSource> sortingProvider)
        {
            SortingProvider = sortingProvider;

            return this;
        }

        /// <summary>
        ///     Applies the build.
        /// </summary>
        /// <returns>The Page Info Builder.</returns>
        public PageInfo<TSource> ApplyBuild()
        {
            ApplyProviders();
            var totalRowCount = Data.Count();
            NormalizePagingOffsetOptions(totalRowCount);

            var pageInfo = new PageInfo<TSource>
            {
                TotalRowCount = totalRowCount,
                Skip = PagingOffsetOptions.Skip,
                Top = PagingOffsetOptions.Top,
                Items = Data.Skip(PagingOffsetOptions.Skip).Take(PagingOffsetOptions.Top).ToList()
            };

            return pageInfo;
        }

        /// <summary>
        ///     Applies the build asynchronous.
        /// </summary>
        /// <returns>The Page Info.</returns>
        public async Task<PageInfo<TSource>> ApplyBuildAsync()
        {
            ApplyProviders();
            var totalRowCount = await Data.CountAsync();
            NormalizePagingOffsetOptions(totalRowCount);

            var pageInfo = new PageInfo<TSource>
            {
                TotalRowCount = totalRowCount,
                Skip = PagingOffsetOptions.Skip,
                Top = PagingOffsetOptions.Top,
                Items = await Data.Skip(PagingOffsetOptions.Skip).Take(PagingOffsetOptions.Top).ToListAsync()
            };

            return pageInfo;
        }
    }
}