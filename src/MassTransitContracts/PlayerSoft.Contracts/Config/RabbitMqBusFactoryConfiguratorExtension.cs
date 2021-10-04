using MassTransit;

namespace PlayerSoft.Contracts.Config
{
    public static class RabbitMqBusFactoryConfiguratorExtension
    {
        public static void ConfigureRabbitMqConection(this MassTransit.RabbitMqTransport.IRabbitMqBusFactoryConfigurator cfg, RabbitMqOptions rabbitMqOptions)
        {
            cfg.Host(rabbitMqOptions.HostName, rabbitMqOptions.VirtualHost, c =>
            {
                c.Username(rabbitMqOptions.UserName);
                c.Password(rabbitMqOptions.Password);
            });
        }
    }
}
