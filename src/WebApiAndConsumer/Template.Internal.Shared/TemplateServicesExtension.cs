using Microsoft.Extensions.DependencyInjection;

using Template.Bll.Services;
using Template.Bll.Services.Abstractions;
using Template.Shared.MessageBroker.Extensions.DependencyInjection;
using Template.Shared.MessageBroker.Commands;

namespace Template.Internal.Shared
{
    /// <summary>
    ///     Bll Services.
    /// </summary>
    public static class TemplateServicesExtension
    {
        /// <summary>
        ///     Add bll services.
        /// </summary>
        /// <param name="services">The service collection.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddBllServices(this IServiceCollection services)
        {
            services.AddTransient<IDbInitService, DbInitService>();
            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
            services.AddTransient<IPlayerService, PlayerService>();

            //Setup message service.
            services.AddEventProducer();

            services.AddCommandProducer<ICreatePlayerCommand, IBaseCommandResponse>();

            return services;
        }
    }
}