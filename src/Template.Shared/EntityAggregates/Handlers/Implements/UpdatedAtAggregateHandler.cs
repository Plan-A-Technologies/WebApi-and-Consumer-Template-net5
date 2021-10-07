using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.EntityAggregates.Handlers.Abstractions;
using Template.Shared.EntityAggregates.States.Abstractions;

namespace Template.Shared.EntityAggregates.Handlers.Implements
{
    /// <summary>
    /// The Updated At Aggregate Handler
    /// </summary>
    /// <seealso cref="Template.Shared.EntityAggregates.Handlers.Abstractions.AbstractAggregateHandler&lt;Template.Shared.EntityAggregates.States.Abstractions.IUpdatedAtAggregate&gt;" />
    public class UpdatedAtAggregateHandler : AbstractAggregateHandler<IUpdatedAtAggregate>
    {
        /// <summary>
        /// Handles the specified aggregate.
        /// </summary>
        /// <param name="aggregate">The aggregate.</param>
        /// <returns>handled aggregate</returns>
        public override object Handle(object aggregate)
        {
            ((IUpdatedAtAggregate)aggregate).UpdatedAt = DateTime.Now;

            return base.Handle(aggregate);
        }
    }
}
