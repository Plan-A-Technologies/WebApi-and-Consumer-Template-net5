using System;
using System.Threading.Tasks;
using MassTransit;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Contracts;

namespace PlayerSoft.Template.Worker.Consumers
{
    public class PlayerConsumer : IConsumer<ICreatePlayer>
    {
        private readonly IPlayerService _playerService;

        public PlayerConsumer(IPlayerService playerService)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
        }

        public async Task Consume(ConsumeContext<ICreatePlayer> context)
        {
            var player = await _playerService.CreatePlayer(context.Message.Player);

            await context.RespondAsync(player);
        }
    }
}
