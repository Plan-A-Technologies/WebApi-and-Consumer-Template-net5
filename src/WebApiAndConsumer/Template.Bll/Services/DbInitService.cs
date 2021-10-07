using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Template.Bll.Services.Abstractions;
using Template.Dal;

namespace Template.Bll.Services
{
    /// <inheritdoc/>
    public class DbInitService : IDbInitService
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly AppDbContext _context;
        /// <summary>
        /// The _logger.
        /// </summary>
        private readonly ILogger<DbInitService> _logger;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public DbInitService(AppDbContext context, ILogger<DbInitService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task InitDb()
        {
            await _context.Database.MigrateAsync();
        }

        /// <inheritdoc/>
        public async Task<bool> CheckConnection()
        {
            return await _context.Database.CanConnectAsync();
        }
    }
}
