using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Shared.EntityAggregates.States.Abstractions
{
    /// <summary>
    /// The Created At Aggregate Interface.
    /// </summary>
    /// <seealso cref="Template.Shared.EntityAggregates.States.Abstractions.IAggregate" />
    public interface ICreatedAtAggregate : IAggregate
    {
        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        /// <value>
        /// The created at.
        /// </value>
        DateTime CreatedAt { get; set; }
    }
}
