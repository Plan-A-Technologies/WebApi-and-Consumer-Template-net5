using System;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Contracts;

namespace PlayerSoft.Template.Worker.Consumers
{
    /// <summary>
    /// The consumer for player
    /// </summary>
    public class PlayerConsumer : IConsumer<ICreatePlayer>
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
        public async Task Consume(ConsumeContext<ICreatePlayer> context)
        {
            using var scope = _scopeFactory.CreateScope();
            var playerService = scope.ServiceProvider.GetRequiredService<IPlayerService>();

            var player = await playerService.CreatePlayer(context.Message.Player);

            await context.RespondAsync(player);
        }
    }
}
