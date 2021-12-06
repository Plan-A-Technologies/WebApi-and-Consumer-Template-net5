using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FluentValidation;

using Microsoft.AspNetCore.Mvc.Filters;

using Template.Shared.Errors;
using Template.Shared.Exceptions;
using Template.Shared.Extensions;

namespace Template.Shared.Filters
{
    /// <summary>
    ///     The Model validation filter.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Filters.IAsyncActionFilter"/>
    public class RequestModelValidationFilter : IAsyncActionFilter
    {
        private readonly IValidatorFactory _validatorFactory;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RequestModelValidationFilter"/> class.
        /// </summary>
        /// <param name="validatorFactory">The validator factory.</param>
        public RequestModelValidationFilter(IValidatorFactory validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        /// <summary>
        ///     Called asynchronously before the action, after model binding is complete.
        /// </summary>
        /// <param name="context">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutingContext"/>.</param>
        /// <param name="next">The <see cref="T:Microsoft.AspNetCore.Mvc.Filters.ActionExecutionDelegate"/>. Invoked to execute the next action filter or the action itself.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var allErrors = new List<ErrorModel>();

            if (context.ActionArguments.Count == 0)
            {
                await next();

                return;
            }

            foreach (var (_, value) in context.ActionArguments)
            {
                if (value == null)
                {
                    continue;
                }

                var validator = _validatorFactory.GetValidator(value.GetType());

                if (validator == null)
                {
                    continue;
                }

                var validationContext = new ValidationContext<object>(value);
                var result = await validator.ValidateAsync(validationContext);

                if (result.IsValid)
                {
                    continue;
                }

                allErrors.AddRange(result.GetErrors());
            }

            if (allErrors.Any())
            {
                throw new BadRequestException(allErrors);
            }

            await next();
        }
    }
}