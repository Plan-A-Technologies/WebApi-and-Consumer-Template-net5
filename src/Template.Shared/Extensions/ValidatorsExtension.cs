using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.DependencyInjection;
using Template.Shared.Errors;

namespace Template.Shared.Extensions
{
    /// <summary>
    ///     Validators extension.
    /// </summary>
    public static class ValidatorsExtension
    {
        /// <summary>
        /// Adds the validator.
        /// </summary>
        /// <typeparam name="TInstance">The type of the instance.</typeparam>
        /// <typeparam name="TValidator">The type of the validator.</typeparam>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection AddValidator<TInstance, TValidator>(this IServiceCollection services)
            where TValidator : class, IValidator<TInstance>
        {
            services.AddScoped<IValidator<TInstance>, TValidator>();
            return services;
        }

        /// <summary>
        ///     Gets the errors.
        /// </summary>
        /// <param name="validationResult">The validation result.</param>
        /// <returns>Collection of errors</returns>
        public static IList<ErrorModel> GetErrors(this ValidationResult validationResult)
        {
            return validationResult.Errors.Select(e => new ErrorModel(e.ErrorCode)
            {
                Message = e.ErrorMessage
            }).ToList();
        }
    }
}