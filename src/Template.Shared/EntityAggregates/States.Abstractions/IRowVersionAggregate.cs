using System.ComponentModel.DataAnnotations;

namespace Template.Shared.EntityAggregates.States.Abstractions
{
    /// <summary>
    /// Row Version Aggregate Interface.
    /// </summary>
    /// <seealso cref="Template.Shared.EntityAggregates.States.Abstractions.IAggregate" />
    public interface IRowVersionAggregate : IAggregate
    {
        /// <summary>
        /// Gets or sets the row version.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        [Timestamp]
        byte[] RowVersion { get; set; }
    }
}
