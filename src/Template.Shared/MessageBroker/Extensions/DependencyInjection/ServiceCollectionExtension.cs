using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.MessageBroker.Services;
using Template.Shared.MessageBroker.Services.Abstractions;

namespace Template.Shared.MessageBroker.Extensions.DependencyInjection
{
    /// <summary>
    /// Service Collection Extension.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Adds the event producer.
        /// </summary>
        /// <param name="services">The services.</param>
        public static IServiceCollection AddEventProducer(this IServiceCollection services)
        {
            services.AddTransient<IEventProducer, EventProducer>();

            return services;
        }

        /// <summary>
        /// Adds the command producer.
        /// </summary>
        /// <typeparam name="TCommand">The type of the command.</typeparam>
        /// <typeparam name="TResponse">The type of the response.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddCommandProducer<TCommand, TResponse>(this IServiceCollection services)
            where TCommand : class
            where TResponse : class
        {
            services.AddTransient<ICommandProducer<TCommand, TResponse>, CommandProducer<TCommand, TResponse>>();

            return services;
        }
    }
}
