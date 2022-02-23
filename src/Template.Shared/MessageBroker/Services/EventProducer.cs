using MassTransit;
using System;
using System.Threading.Tasks;
using Template.Shared.MessageBroker.Services.Abstractions;

namespace Template.Shared.MessageBroker.Services
{
    /// <summary>
    /// Event Producer.
    /// </summary>
    /// <seealso cref="Template.Shared.MessageBroker.Services.Abstractions.IEventProducer" />
    public class EventProducer : IEventProducer
    {
        private readonly IBus _massTransitBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventProducer"/> class.
        /// </summary>
        /// <param name="massTransitBus">The mass transit bus.</param>
        /// <exception cref="System.ArgumentNullException">massTransitBus</exception>
        public EventProducer(IBus massTransitBus)
        {
            _massTransitBus = massTransitBus ?? throw new ArgumentNullException(nameof(massTransitBus));
        }

        /// <summary>
        /// Publishes the event.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="eventValues">The event values.</param>
        public async Task PublishEvent<TEvent>(object eventValues) where TEvent : class
        {
            await _massTransitBus.Publish<TEvent>(eventValues);
        }
    }
}
