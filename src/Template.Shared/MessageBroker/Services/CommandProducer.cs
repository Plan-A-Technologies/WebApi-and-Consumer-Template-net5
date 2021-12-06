using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Template.Shared.MessageBroker.Services.Abstractions;

namespace Template.Shared.MessageBroker.Services
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TResponse">The type of the response.</typeparam>
    /// <seealso cref="Template.Shared.MessageBroker.Services.Abstractions.ICommandProducer&lt;TCommand, TResponse&gt;" />
    public class CommandProducer<TCommand, TResponse> : ICommandProducer<TCommand, TResponse>
        where TCommand : class
        where TResponse : class
    {
        /// <summary>
        ///     The Request Client.
        /// </summary>
        private readonly IRequestClient<TCommand> _client;

        /// <summary>
        ///     The logger.
        /// </summary>
        private readonly ILogger<CommandProducer<TCommand, TResponse>> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandProducer{TCommand, TResponse}"/> class.
        /// </summary>
        /// <param name="client">The client.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="System.ArgumentNullException">
        /// client
        /// or
        /// logger
        /// </exception>
        public CommandProducer(IRequestClient<TCommand> client, ILogger<CommandProducer<TCommand, TResponse>> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<TResponse> SendCommand(object command)
        {
            Response<TResponse> response = await _client.GetResponse<TResponse>(command);

            _logger.LogInformation($"Produce command: {JsonConvert.SerializeObject(response.Message)}");

            return response.Message;
        }
    }
}
