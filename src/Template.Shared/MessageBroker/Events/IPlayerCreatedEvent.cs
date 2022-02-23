using Template.Shared.DtoContracts;

namespace Template.Shared.MessageBroker.Events
{
    /// <summary>
    /// Player Created Event.
    /// </summary>
    public interface IPlayerCreatedEvent
    {
        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        IPlayerDto Player { get; set; }
    }
}
