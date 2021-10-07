using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.EntityAggregates.States.Abstractions;

namespace Template.Shared.EntityAggregates.Handlers.Abstractions
{
    public abstract class AbstractAggregateHandler<TAggregate> : IAggregateHandler
        where TAggregate : IAggregate
    {
        private IAggregateHandler _nextHandler;

        public IAggregateHandler SetNext(IAggregateHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }

        public virtual object Handle(object aggregate)
        {
            return this._nextHandler?.Handle(aggregate);
        }

        public Task<IAggregateHandler> SetNextAsync(IAggregateHandler handler)
        {
            return Task.Run(() => this.SetNext(handler));
        }

        public Task<object> HandleAsync(object aggregate)
        {
            return Task.Run(() => this.Handle(aggregate));
        }
    }
}
