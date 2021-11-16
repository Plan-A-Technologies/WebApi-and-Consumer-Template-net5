using Microsoft.EntityFrameworkCore;
using Template.Dal.Configs;
using Template.Dal.Entities;
using Template.Shared.EFCore;
using Template.Shared.EFCore.Auditable;

namespace Template.Dal
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class AppDbContext : AuditableDbContext
    {
        /// <summary>
        /// Players entity.
        /// </summary>
        public virtual DbSet<Player> Players { get; set; }

        /// <summary>
        /// Players phone entity.
        /// </summary>
        public virtual DbSet<PlayerPhone> PlayerPhones { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="entityAuditProvider">The entity audit provider.</param>
        public AppDbContext(DbContextOptions<AppDbContext> options, IEntityAuditProvider entityAuditProvider)
            : base(options, entityAuditProvider)
        {
        }

        /// <summary>
        /// OnModelCreating event.
        /// </summary>
        /// <param name="modelBuilder">ModelBuilder <see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfig());
        }
    }
}
