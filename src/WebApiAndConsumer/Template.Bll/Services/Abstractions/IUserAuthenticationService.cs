using System.Threading.Tasks;

namespace Template.Bll.Services.Abstractions
{
    /// <summary>
    /// User Authentication Service.
    /// </summary>
    public interface IUserAuthenticationService
    {
        /// <summary>
        /// Gets the user identifier.
        /// </summary>
        /// <returns>User id</returns>
        Task<int> GetUserId();
    }
}
