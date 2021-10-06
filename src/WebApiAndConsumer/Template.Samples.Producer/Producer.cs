using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Template.Bll.Dto;
using Template.Bll.Messages;
using Template.Shared.DtoContracts;
using Template.Shared.Messages;

namespace Template.Samples.Producer
{
    /// <summary>
    /// 
    /// </summary>
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IRequestClient<IPlayerMessage> _createAppointmentClient;
        readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="serviceProvider"></param>
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stoppingToken"></param>
        /// <returns></returns>
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _serviceProvider.CreateScope();

            _createAppointmentClient = scope.ServiceProvider.GetRequiredService<IRequestClient<IPlayerMessage>>();

            await Task.Delay(1000, stoppingToken);

            var pl = await _createAppointmentClient.GetResponse<IPlayerDto>(new PlayerMessage
            {
                PlayerDto = new PlayerDto()
            }, stoppingToken);
        }
    }
}