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
    /// The worker for checking consumers
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Hosting.BackgroundService" />
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IRequestClient<IPlayerMessage> _createAppointmentClient;
        readonly IServiceProvider _serviceProvider;

        /// <summary>
        /// Initializes a new instance of the <see cref="Worker"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="serviceProvider">The service provider.</param>
        /// <exception cref="System.ArgumentNullException">serviceProvider</exception>
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        /// <summary>
        /// This method is called when the <see cref="T:Microsoft.Extensions.Hosting.IHostedService" /> starts. The implementation should return a task that represents
        /// the lifetime of the long running operation(s) being performed.
        /// </summary>
        /// <param name="stoppingToken">Triggered when <see cref="M:Microsoft.Extensions.Hosting.IHostedService.StopAsync(System.Threading.CancellationToken)" /> is called.</param>
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