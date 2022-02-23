using System.Collections.Generic;

namespace Template.Shared.DataQueries.Pagination
{
    /// <summary>
    ///     The Page Info
    /// </summary>
    /// <typeparam name="T">The type of the data</typeparam>
    public class PageInfo<T>
    {
        /// <summary>
        ///     Gets or sets the skip.
        /// </summary>
        /// <value>
        ///     The skip.
        /// </value>
        public int Skip { get; set; }

        /// <summary>
        ///     Gets or sets the top.
        /// </summary>
        /// <value>
        ///     The top.
        /// </value>
        public int Top { get; set; }

        /// <summary>
        ///     Gets or sets the total row count.
        /// </summary>
        /// <value>
        ///     The total row count.
        /// </value>
        public int TotalRowCount { get; set; }

        /// <summary>
        ///     Gets or sets the items.
        /// </summary>
        /// <value>
        ///     The items.
        /// </value>
        public IEnumerable<T> Items { get; set; }
    }
}