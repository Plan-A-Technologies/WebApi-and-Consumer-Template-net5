using Template.Api.ViewModels.Request;

namespace Template.Api.Validators.Players
{
    /// <summary>
    /// Create Player Validator.
    /// </summary>
    public class CreatePlayerValidator : BasePlayerValidator<CreatePlayerRequestViewModel>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreatePlayerValidator"/> class.
        /// </summary>
        public CreatePlayerValidator()
        {
        }
    }
}
