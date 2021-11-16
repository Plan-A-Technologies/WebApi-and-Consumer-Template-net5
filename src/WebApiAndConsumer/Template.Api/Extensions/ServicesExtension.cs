using Microsoft.Extensions.DependencyInjection;
using Template.Bll.Services;
using Template.Bll.Services.Abstractions;

namespace Template.Api.Extensions
{
    /// <summary>
    /// Services extensions
    /// </summary>
    public static class ServicesExtension
    {
        /// <summary>
        /// Add services.
        /// </summary>
        /// <param name="services"><see cref="IServiceCollection"/></param>
        /// <returns><see cref="IServiceCollection"/></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IDbInitService, DbInitService>();
            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
            return services;
        }
    }
}
