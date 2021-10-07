using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Shared.EntityAggregates.States.Abstractions
{
    /// <summary>
    /// The Updated At Interface
    /// </summary>
    /// <seealso cref="Template.Shared.EntityAggregates.States.Abstractions.IAggregate" />
    public interface IUpdatedAtAggregate: IAggregate
    {
        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        /// <value>
        /// The updated at.
        /// </value>
        DateTime? UpdatedAt { get; set; }
    }
}
