namespace Template.Shared.DataQueries.Pagination.Options
{
    /// <summary>
    ///     The Paging Offset Options
    /// </summary>
    public interface IPagingOffsetOptions
    {
        /// <summary>
        ///     Gets the skip.
        /// </summary>
        /// <value>
        ///     The skip.
        /// </value>
        int Skip { get; set; }

        /// <summary>
        ///     Gets the top.
        /// </summary>
        /// <value>
        ///     The top.
        /// </value>
        int Top { get; set; }
    }
}