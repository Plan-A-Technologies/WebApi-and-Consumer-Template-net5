using Microsoft.EntityFrameworkCore;
using Template.Dal.Configs;
using Template.Dal.Entities;

namespace Template.Dal
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class AppDbContext : DbContext
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
        public AppDbContext()
        {
        }

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="options">DbContextOptions <see cref="DbContextOptions"/></param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
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
