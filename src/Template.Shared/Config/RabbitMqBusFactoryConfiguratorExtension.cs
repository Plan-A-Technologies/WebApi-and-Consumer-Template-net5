using MassTransit;

namespace Template.Shared.Config
{
    /// <summary>
    /// Rabbit mq bus factory configurator extension.
    /// </summary>
    public static class RabbitMqBusFactoryConfiguratorExtension
    {
        /// <summary>
        /// Configures rabbit mq connection.
        /// </summary>
        /// <param name="cfg">The Rabbit Mq Bus Factory Configurator.</param>
        /// <param name="rabbitMqOptions">The rabbit mq options.</param>
        public static void ConfigureRabbitMqConnection(this MassTransit.RabbitMqTransport.IRabbitMqBusFactoryConfigurator cfg, RabbitMqOptions rabbitMqOptions)
        {
            cfg.Host(rabbitMqOptions.HostName, rabbitMqOptions.VirtualHost, c =>
            {
                c.Username(rabbitMqOptions.UserName);
                c.Password(rabbitMqOptions.Password);
            });
        }
    }
}
