using Microsoft.Extensions.DependencyInjection;
using Template.Shared.EFCore.Auditable;

namespace Template.Shared.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class EFCoreServicesExtention
    {
        /// <summary>
        /// Adds the entity audit provider.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddEntityAuditProvider<T>(this IServiceCollection services)
            where T : class, IEntityAuditProvider
        {
            services.AddTransient<IEntityAuditProvider, T>();

            return services;
        }
    }
}
