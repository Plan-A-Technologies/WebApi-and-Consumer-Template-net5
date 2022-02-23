namespace Template.Shared.DataQueries.Sorting.Abstractions
{
    /// <summary>
    ///     The Sorting Options.
    /// </summary>
    public interface ISortingOptions
    {
        /// <summary>
        ///     Gets the order by.
        /// </summary>
        /// <value>
        ///     The order by.
        /// </value>
        string OrderBy { get; }

        /// <summary>
        ///     Gets a value indicating whether this is asc.
        /// </summary>
        /// <value>
        ///     <c>true</c> if asc; otherwise, <c>false</c>.
        /// </value>
        bool Asc { get; }

        /// <summary>
        ///     Gets the then by.
        /// </summary>
        /// <value>
        ///     The then by.
        /// </value>
        string ThenBy { get; }

        /// <summary>
        ///     Gets a value indicating whether this is asc.
        /// </summary>
        /// <value>
        ///     <c>true</c> if asc; otherwise, <c>false</c>.
        /// </value>
        bool ThenByAsc { get; }
    }
}