using Microsoft.Extensions.DependencyInjection;
using PlayerSoft.Template.Bll.Contracts;
using PlayerSoft.Template.Bll.Services;

namespace PlayerSoft.Template.Api.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IDbInitService, DbInitService>();
            return services;
        }
    }
}
