namespace Template.Shared.MessageBroker.Commands
{
    /// <summary>
    ///     The base command response.
    /// </summary>
    public interface IBaseCommandResponse
    {
        /// <summary>
        ///     Gets or sets a value indicating whether this instance is success.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is success; otherwise, <c>false</c>.
        /// </value>
        bool IsSuccess { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>
        ///     The message.
        /// </value>
        string Message { get; set; }
    }
}
