namespace Template.Shared.DataQueries.Pagination.Options
{
    /// <inheritdoc/>
    /// <seealso cref="Template.Shared.DataQueries.Pagination.Options.IPagingOffsetOptions"/>
    public class PagingOffsetOptions : IPagingOffsetOptions
    {
        /// <inheritdoc/>
        public int Skip { get; set; }

        /// <inheritdoc/>
        public int Top { get; set; }
    }
}