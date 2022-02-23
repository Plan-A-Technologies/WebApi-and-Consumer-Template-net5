using System.Threading.Tasks;

namespace Template.Shared.MessageBroker.Services.Abstractions
{
    /// <summary>
    /// Command Producer.
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    public interface ICommandProducer<TCommand, TResponse>
        where TCommand : class
        where TResponse : class
    {
        /// <summary>
        /// Sends the command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The response.</returns>
        Task<TResponse> SendCommand(object command);
    }
}
