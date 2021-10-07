using System;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Shared.Config;
using Template.Shared.Messages;

namespace Template.Samples.Producer
{
    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args"></param>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var rabbitMqOptions = hostContext.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();

                    services.AddMassTransit(x =>
                    {
                        x.AddRequestClient<IPlayerMessage>(TimeSpan.FromSeconds(10));

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureRabbitMqConnection(rabbitMqOptions);
                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddHostedService<Producer>();
                });
    }
}
