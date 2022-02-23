using Microsoft.Extensions.DependencyInjection;
using Template.Api.Validators.Players;
using Template.Api.ViewModels.Request;
using Template.Shared.Extensions;

namespace Template.Api.Extensions
{
    /// <summary>
    /// Validators Extension.
    /// </summary>
    public static class ValidatorsExtension
    {
        /// <summary>
        /// Adds the validators.
        /// </summary>
        /// <param name="services">The services.</param>
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidator<CreatePlayerRequestViewModel, CreatePlayerValidator>();
            //services.AddScoped<IValidator<UpdateUserRequestViewModel>, UpdateUserValidator>();

            return services;
        }
    }
}
