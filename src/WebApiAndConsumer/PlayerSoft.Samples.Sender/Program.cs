using System;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayerSoft.Contracts.Config;
using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Samples.Sender
{
    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// CreateHostBuilder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var rabbitMqOptions = hostContext.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();

                    services.AddMassTransit(x =>
                    {
                        x.AddRequestClient<ICreatePlayer>(TimeSpan.FromSeconds(10));

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureRabbitMqConection(rabbitMqOptions);
                            cfg.ConfigureEndpoints(context);
                        });
                    });

                    services.AddHostedService<Worker>();
                });
    }
}
