using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.EntityAggregates.States.Abstractions
{
    /// <summary>
    /// The Updated By Aggregate Interface
    /// </summary>
    /// <typeparam name="TUpdatedBy">The type of the updated by.</typeparam>
    /// <seealso cref="Template.Shared.EntityAggregates.States.Abstractions.IAggregate" />
    interface IUpdatedByAggregate<TUpdatedBy> : IAggregate
    {
        /// <summary>
        /// Gets or sets the updated by.
        /// </summary>
        /// <value>
        /// The updated by.
        /// </value>
        TUpdatedBy UpdatedBy { get; set; }
    }
}
