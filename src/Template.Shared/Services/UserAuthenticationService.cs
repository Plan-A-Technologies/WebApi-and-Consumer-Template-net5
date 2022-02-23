using System;
using System.Security.Claims;

using IdentityModel;

using Microsoft.AspNetCore.Http;

using Template.Shared.Services.Abstractions;

namespace Template.Shared.Services
{
    /// <inheritdoc/>
    public class UserAuthenticationService : IUserAuthenticationService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UserAuthenticationService"/> class.
        /// </summary>
        /// <param name="httpContextAccessor">
        ///     <see cref="IHttpContextAccessor"/>
        /// </param>
        public UserAuthenticationService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        ///     Gets user identifier
        /// </summary>
        /// <example>
        ///     <c>Use in ConfigureServices:</c>
        ///     <code>
        ///     services.AddHttpContextAccessor();
        ///     services.AddTransient&lt;IUserAuthenticationService, UserAuthenticationService&gt;();
        ///     </code>
        /// </example>
        /// <exception cref="ArgumentException">
        ///     User not found
        /// </exception>
        public int GetUserId()
        {
            var value = _httpContextAccessor?.HttpContext?.User.FindFirstValue(JwtClaimTypes.Subject);

            if (int.TryParse(value, out var userId))
            {
                return userId;
            }

            throw new ArgumentException(nameof(userId));
        }
    }
}