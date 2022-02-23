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
    ///     The Selectable Page Info Builder.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TDestinition">The type of the destinition.</typeparam>
    /// <seealso cref="Template.Shared.DataQueries.Builder.Abstractions.AbstractPageInfoBuilder&lt;TSource&gt;"/>
    public class SelectablePageInfoBuilder<TSource, TDestinition> : AbstractPageInfoBuilder<TSource>
    {
        /// <summary>
        ///     Gets or sets the selector.
        /// </summary>
        /// <value>
        ///     The selector.
        /// </value>
        protected Expression<Func<TSource, TDestinition>> Selector { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SelectablePageInfoBuilder{TSource, TDestinition}"/> class.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <param name="defaultPagingOffsetTop"></param>
        public SelectablePageInfoBuilder(IQueryable<TSource> data, IPagingOffsetOptions options, int defaultPagingOffsetTop = 10)
        {
            Data = data;
            PagingOffsetOptions = options;
            DefaultPagingOffsetTop = defaultPagingOffsetTop;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SelectablePageInfoBuilder{TSource, TDestinition}"/> class.
        /// </summary>
        /// <param name="pageInfoBuilder">The page information builder.</param>
        /// <param name="selector">The selector to map property of Source to Destinition.</param>
        public SelectablePageInfoBuilder(PageInfoBuilder<TSource> pageInfoBuilder, Expression<Func<TSource, TDestinition>> selector)
        {
            Data = pageInfoBuilder.Data;
            SortingProvider = pageInfoBuilder.SortingProvider;
            FilteringProvider = pageInfoBuilder.FilteringProvider;
            PagingOffsetOptions = pageInfoBuilder.PagingOffsetOptions;
            DefaultPagingOffsetTop = pageInfoBuilder.DefaultPagingOffsetTop;
            Selector = selector;
        }

        /// <summary>
        ///     Adds the filtering provider.
        /// </summary>
        /// <param name="filteringProvider">The filtering provider.</param>
        /// <returns>The Selectable Page Info Builder.</returns>
        public SelectablePageInfoBuilder<TSource, TDestinition> AddFilteringProvider(IFilteringProvider<TSource> filteringProvider)
        {
            FilteringProvider = filteringProvider;

            return this;
        }

        /// <summary>
        ///     Adds the sorting provider.
        /// </summary>
        /// <param name="sortingProvider">The sorting provider.</param>
        /// <returns>The Selectable Page Info Builder.</returns>
        public SelectablePageInfoBuilder<TSource, TDestinition> AddSortingProvider(ISortingProvider<TSource> sortingProvider)
        {
            SortingProvider = sortingProvider;

            return this;
        }

        /// <summary>
        ///     Adds selector.
        /// </summary>
        /// <param name="selector">The selector.</param>
        public SelectablePageInfoBuilder<TSource, TDestinition> AddSelector(Expression<Func<TSource, TDestinition>> selector)
        {
            Selector = selector;

            return this;
        }

        /// <summary>
        ///     Applies the build.
        /// </summary>
        /// <returns>The Page Info Builder.</returns>
        public PageInfo<TDestinition> ApplyBuild()
        {
            CheckSelector(Selector);

            ApplyProviders();
            var totalRowCount = Data.Count();
            NormalizePagingOffsetOptions(totalRowCount);

            var pageInfo = new PageInfo<TDestinition>
            {
                TotalRowCount = totalRowCount,
                Skip = PagingOffsetOptions.Skip,
                Top = PagingOffsetOptions.Top,
                Items = Data.Skip(PagingOffsetOptions.Skip)
                    .Take(PagingOffsetOptions.Top)
                    .Select(Selector).ToList()
            };

            return pageInfo;
        }

        /// <summary>
        ///     Applies the build asynchronous.
        /// </summary>
        /// <returns>The Page Info Builder.</returns>
        public async Task<PageInfo<TDestinition>> ApplyBuildAsync()
        {
            CheckSelector(Selector);

            ApplyProviders();
            var totalRowCount = await Data.CountAsync();
            NormalizePagingOffsetOptions(totalRowCount);

            var pageInfo = new PageInfo<TDestinition>
            {
                TotalRowCount = totalRowCount,
                Skip = PagingOffsetOptions.Skip,
                Top = PagingOffsetOptions.Top,
                Items = await Data.Skip(PagingOffsetOptions.Skip)
                    .Take(PagingOffsetOptions.Top)
                    .Select(Selector).ToListAsync()
            };

            return pageInfo;
        }

        private static void CheckSelector(Expression<Func<TSource, TDestinition>> selector)
        {
            if (selector == null)
            {
                throw new ArgumentNullException(nameof(selector));
            }
        }
    }
}