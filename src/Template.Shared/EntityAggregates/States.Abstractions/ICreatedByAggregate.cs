using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template.Shared.EntityAggregates.States.Abstractions
{
    /// <summary>
    /// The Created by aggregate Interface
    /// </summary>
    /// <typeparam name="TCreatedBy">The type of the created by.</typeparam>
    /// <seealso cref="Template.Shared.EntityAggregates.States.Abstractions.IAggregate" />
    public interface ICreatedByAggregate<TCreatedBy> : IAggregate
    {
        /// <summary>
        /// Gets or sets the created by.
        /// </summary>
        /// <value>
        /// The created by.
        /// </value>
        TCreatedBy CreatedBy { get; set; }
    }
}
