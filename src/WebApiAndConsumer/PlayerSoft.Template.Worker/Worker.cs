using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Models;

namespace PlayerSoft.Template.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IRequestClient<ICreatePlayer> _createAppointmentClient;
        readonly IServiceProvider _serviceProvider;

        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();

            _createAppointmentClient = scope.ServiceProvider.GetRequiredService<IRequestClient<ICreatePlayer>>();

            await Task.Delay(1000, stoppingToken);

            var pl = await _createAppointmentClient.GetResponse<IPlayer>(new CreatePlayer()
            {
                Player = new Player()
            }, stoppingToken);
        }
    }
}
