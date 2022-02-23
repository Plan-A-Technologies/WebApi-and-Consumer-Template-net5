using System;
using Template.Bll.Services.Abstractions;

namespace Template.Bll.Services
{
    /// <inheritdoc/>
    /// <seealso cref="Template.Bll.Services.Abstractions.IUserAuthenticationService" />
    public class UserAuthenticationService : IUserAuthenticationService
    {
        /// <inheritdoc/>
        public int GetUserId()
        {
            return new Random().Next(0, 100);
        }
    }
}
