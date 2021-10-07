using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Template.Bll.Services.Abstractions;
using Template.Shared.Messages;

namespace Template.Consumer.Consumers
{
    /// <summary>
    /// The consumer for player
    /// </summary>
    public class PlayerConsumer : IConsumer<IPlayerMessage>
    {
        private readonly IServiceScopeFactory _scopeFactory;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="scopeFactory"></param>
        public PlayerConsumer(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
        }

        /// <inheritdoc/>
        public async Task Consume(ConsumeContext<IPlayerMessage> context)
        {
            using var scope = _scopeFactory.CreateScope();
            var playerService = scope.ServiceProvider.GetRequiredService<IPlayerService>();

            var player = await playerService.CreatePlayer(context.Message.PlayerDto);

            await context.RespondAsync(player);
        }
    }
}
