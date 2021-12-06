namespace Template.Shared.Services.Abstractions
{
    /// <summary>
    ///     The user service.
    /// </summary>
    public interface IUserAuthenticationService
    {
        /// <summary>
        ///     Gets the user identifier.
        /// </summary>
        /// <returns>The user identifier.</returns>
        int GetUserId();
    }
}