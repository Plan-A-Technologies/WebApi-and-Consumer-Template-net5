using System.Threading.Tasks;

namespace Template.Shared.MessageBroker.Services.Abstractions
{
    /// <summary>
    /// Event Producer.
    /// </summary>
    public interface IEventProducer
    {
        /// <summary>
        /// Publishes the event.
        /// </summary>
        /// <typeparam name="TEvent">The type of the event.</typeparam>
        /// <param name="eventValues">The event values.</param>
        Task PublishEvent<TEvent>(object eventValues) where TEvent : class;
    }
}
