using System;
using System.Collections.Generic;

using MassTransit;

using Microsoft.Extensions.DependencyInjection;

using Template.Shared.Config;
using Template.Shared.MessageBroker.Commands;

namespace Template.Internal.Shared
{
    /// <summary>
    ///     Masstransit extension
    /// </summary>
    public static class MasstransitExtension
    {
        /// <summary>
        ///     Adds user management services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <param name="rabbitMqOptions">The rabbit mq options.</param>
        /// <param name="consumerTypes">The cosumer types.</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddMassTransitServices(this IServiceCollection services, RabbitMqOptions rabbitMqOptions, IEnumerable<Type> consumerTypes = null)
        {
            services.AddMassTransitHostedService();
            services.AddMassTransit(x =>
            {
                //Setup masstransit consumers.
                if (consumerTypes != null)
                {
                    foreach (var type in consumerTypes)
                    {
                        x.AddConsumer(type);
                    }
                }

                //Setup masstransit rabbit mq connection.
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.ConfigureRabbitMqConnection(rabbitMqOptions);
                    cfg.ConfigureEndpoints(context);
                });

                //Setup masstransit request client.
                x.AddRequestClient<ICreatePlayerCommand>(TimeSpan.FromSeconds(rabbitMqOptions.DefaultTimeout));
            });

            return services;
        }
    }
}