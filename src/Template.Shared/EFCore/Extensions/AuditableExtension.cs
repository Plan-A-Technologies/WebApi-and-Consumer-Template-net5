using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Shared.EFCore.Auditable;

namespace Template.Shared.EFCore.Extensions
{
    /// <summary>
    /// Auditable Extension.
    /// </summary>
    public static class AuditableExtension
    {
        /// <summary>
        /// Adds the entity auditable provider.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddEntityAuditableProvider<TImplementation>(this IServiceCollection services)
            where TImplementation : class, IEntityAuditProvider
        {
            services.AddTransient<IEntityAuditProvider, TImplementation>();

            return services;
        }
    }
}
