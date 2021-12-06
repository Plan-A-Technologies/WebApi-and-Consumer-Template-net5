using Template.Shared.Services.Abstractions;

namespace Template.Shared.Services
{
    /// <inheritdoc/>
    public class MockUserAuthenticationService : IUserAuthenticationService
    {
        /// <inheritdoc/>
        public int GetUserId()
        {
            return 1;
        }
    }
}