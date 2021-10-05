using Microsoft.Extensions.DependencyInjection;
using PlayerSoft.Template.Bll.Contracts;
using PlayerSoft.Template.Bll.Services;

namespace PlayerSoft.Template.Api.Extensions
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
            return services;
        }
    }
}
