using Microsoft.Extensions.DependencyInjection;
using Template.Shared.EFCore.Auditable;

namespace Template.Shared.Extensions.DependencyInjection
{
    public static class EFCoreServicesExtention
    {
        public static IServiceCollection AddEntityAuditProvider<T>(this IServiceCollection services)
            where T : class, IEntityAuditProvider
        {
            services.AddTransient<IEntityAuditProvider, T>();

            return services;
        }
    }
}
