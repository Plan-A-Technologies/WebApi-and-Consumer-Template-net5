using Microsoft.EntityFrameworkCore;
using PlayerSoft.Template.Dal.Configs;
using PlayerSoft.Template.Dal.Entities;

namespace PlayerSoft.Template.Dal.EF
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class PlayerSoftContext : DbContext
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
        /// .ctor
        /// </summary>
        /// <param name="options">DbContextOptions <see cref="DbContextOptions"/></param>
        public PlayerSoftContext(DbContextOptions<PlayerSoftContext> options) : base(options)
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
