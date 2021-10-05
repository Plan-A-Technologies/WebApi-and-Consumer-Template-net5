using System;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayerSoft.Contracts.Config;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Contracts;
using PlayerSoft.Template.Bll.Services;
using PlayerSoft.Template.Dal.EF;
using PlayerSoft.Template.Worker.Consumers;

namespace PlayerSoft.Template.Worker
{
    /// <summary>
    /// The program class.
    /// </summary>
    public class Program
    {
        private const string ConnectionStringName = "PlayerSoftConnection";
  
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

                    services.AddDbContext<PlayerSoftContext>(x =>
                        x.UseSqlServer(dbConnectionString), ServiceLifetime.Transient);

                    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

                    var rabbitMqOptions = hostContext.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();

                    services.AddTransient<IPlayerService, PlayerService>();

                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<PlayerConsumer>();

                        x.AddRequestClient<ICreatePlayer>(TimeSpan.FromSeconds(10));

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureRabbitMqConection(rabbitMqOptions);
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddMassTransitHostedService();
                });
    }
}
