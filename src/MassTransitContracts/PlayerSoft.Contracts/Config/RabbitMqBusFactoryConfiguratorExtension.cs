using MassTransit;

namespace PlayerSoft.Contracts.Config
{
    /// <summary>
    /// 
    /// </summary>
    public static class RabbitMqBusFactoryConfiguratorExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        /// <param name="rabbitMqOptions"></param>
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
