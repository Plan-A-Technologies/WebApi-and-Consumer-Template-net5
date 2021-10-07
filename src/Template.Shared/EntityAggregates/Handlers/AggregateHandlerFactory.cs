using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.EntityAggregates.Handlers.Abstractions;
using Template.Shared.EntityAggregates.Handlers.Implements;
using Template.Shared.EntityAggregates.States.Abstractions;

namespace Template.Shared.EntityAggregates.Handlers
{
    /// <summary>
    /// The Aggregate Handler Chain Factory
    /// </summary>
    public class AggregateHandlerChainFactory
    {
        /// <summary>
        /// Gets or sets the produced.
        /// </summary>
        /// <value>
        /// The produced.
        /// </value>
        public IAggregateHandler Produced { get; protected set; }

        /// <summary>
        /// Produces the specified client.
        /// </summary>
        /// <param name="client">
        ///     The client. <br/>
        ///     The client must implement the interface otherwise null will be produced and returned.
        /// </param>
        /// <returns>Produced Aggregate Handler Chain</returns>
        public IAggregateHandler Produce(object client)
        {
            if (client is IAggregate)
            {
                if (client is IUpdatedAtAggregate)
                {
                    this.AppendOrSetProduced<UpdatedAtAggregateHandler>();
                }
            }

            return this.Produced;
        }

        /// <summary>
        /// Appends the or set produced.
        /// </summary>
        /// <typeparam name="T">Type of producing item</typeparam>
        protected void AppendOrSetProduced<T>() where T: new ()
        {
            Produced = Produced?.SetNext(new UpdatedAtAggregateHandler()) ?? new UpdatedAtAggregateHandler();
        }
    }
}
