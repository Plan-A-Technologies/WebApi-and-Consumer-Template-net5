using System;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Template.Bll.Services;
using Template.Bll.Services.Abstractions;
using Template.Consumer.Consumers;
using Template.Dal;
using Template.Shared.Config;
using Template.Shared.Messages;

namespace Template.Consumer
{
    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The connection string name.
        /// </summary>
        private const string ConnectionStringName = "DbConnection";

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
                    var dbConnectionString = hostContext.Configuration.GetConnectionString(ConnectionStringName);

                    services.AddDbContext<AppDbContext>(x =>
                        x.UseSqlServer(dbConnectionString), ServiceLifetime.Transient);

                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                    var rabbitMqOptions = hostContext.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();

                    services.AddTransient<IPlayerService, PlayerService>();

                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<PlayerConsumer>();

                        x.AddRequestClient<IPlayerMessage>(TimeSpan.FromSeconds(10));

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureRabbitMqConnection(rabbitMqOptions);
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddMassTransitHostedService();
                });
    }
}
