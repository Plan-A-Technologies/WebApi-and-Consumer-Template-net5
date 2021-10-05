using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlayerSoft.Template.Bll.Contracts;
using PlayerSoft.Template.Dal.EF;

namespace PlayerSoft.Template.Bll.Services
{
    /// <inheritdoc/>
    public class DbInitService : IDbInitService
    {
        private readonly PlayerSoftContext _context;
        private readonly ILogger<DbInitService> _logger;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public DbInitService(PlayerSoftContext context, ILogger<DbInitService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task InitDb()
        {
            await _context.Database.MigrateAsync();
        }
    }
}
