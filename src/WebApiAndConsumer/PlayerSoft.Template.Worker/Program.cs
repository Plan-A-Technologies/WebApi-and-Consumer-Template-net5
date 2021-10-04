using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlayerSoft.Contracts.Config;
using PlayerSoft.Template.Worker.Consumers;

namespace PlayerSoft.Template.Worker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var rabbitMqOptions = hostContext.Configuration.GetSection("RabbitMQ").Get<RabbitMqOptions>();

                    services.AddMassTransit(x =>
                    {
                        x.AddConsumer<PlayerConsumer>();

                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.ConfigureRabbitMqConection(rabbitMqOptions);
                            cfg.ConfigureEndpoints(context);
                        });
                    });
                    services.AddMassTransitHostedService();

                    services.AddHostedService<Worker>();
                });
    }
}
