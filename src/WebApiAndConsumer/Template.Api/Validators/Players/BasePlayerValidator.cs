using FluentValidation;
using Template.Api.ViewModels.Request;
using Template.Shared.Errors.Assets;

namespace Template.Api.Validators.Players
{
    /// <summary>
    /// Base Player Validator.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="FluentValidation.AbstractValidator&lt;T&gt;" />
    public class BasePlayerValidator<T> : AbstractValidator<T> where T : BasePlayerRequestViewModel
    {
        private const int NamesMaximumLength = 128;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasePlayerValidator{T}"/> class.
        /// </summary>
        public BasePlayerValidator()
        {
            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("The {PropertyName} field is required.")
                .WithErrorCode(ErrorCodes.TemplateErrors.PlayersErrors.FieldIsRequired);

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("The {PropertyName} field cannot be empty.")
                .WithErrorCode(ErrorCodes.TemplateErrors.PlayersErrors.MinimumFieldLengthRequirement);

            RuleFor(x => x.FirstName)
                .MaximumLength(NamesMaximumLength)
                .WithMessage("The field {PropertyName} must be a string with a maximum length of 128.")
                .WithErrorCode(ErrorCodes.TemplateErrors.PlayersErrors.MaximumFieldLengthRequirement);
        }
        }
}
