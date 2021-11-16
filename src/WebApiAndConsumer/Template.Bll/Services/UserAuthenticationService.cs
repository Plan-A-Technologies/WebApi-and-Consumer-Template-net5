using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Bll.Services.Abstractions;

namespace Template.Bll.Services
{
    /// <inheritdoc/>
    /// <seealso cref="Template.Bll.Services.Abstractions.IUserAuthenticationService" />
    public class UserAuthenticationService : IUserAuthenticationService
    {
        /// <inheritdoc/>
        public async Task<int> GetUserId()
        {
            return await Task.FromResult(new Random().Next(0, 100));
        }
    }
}
