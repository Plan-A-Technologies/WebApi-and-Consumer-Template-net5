using System;
using Template.Bll.Services.Abstractions;
using Template.Shared.EFCore.Auditable;

namespace Template.Bll.Assets
{
    /// <inheritdoc/>
    /// <seealso cref="Template.Shared.EFCore.Auditable.IEntityAuditProvider" />
    public class EntityAuditProvider : IEntityAuditProvider
    {
        private readonly IUserAuthenticationService _userAuthenticationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityAuditProvider"/> class.
        /// </summary>
        /// <param name="userAuthenticationService">The user authentication service.</param>
        /// <exception cref="System.ArgumentNullException">userAuthenticationService</exception>
        public EntityAuditProvider(IUserAuthenticationService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService ?? throw new ArgumentNullException(nameof(userAuthenticationService));
        }

        /// <inheritdoc/>
        public int GetAuditAuthorKey()
        {
            return _userAuthenticationService.GetUserId().GetAwaiter().GetResult();
        }

        /// <inheritdoc/>
        public DateTime GetAuditDate()
        {
            return DateTime.UtcNow;
        }
    }
}
