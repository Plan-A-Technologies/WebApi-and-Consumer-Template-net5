using Microsoft.EntityFrameworkCore;
using PlayerSoft.Template.Dal.Configs;
using PlayerSoft.Template.Dal.Entities;

namespace PlayerSoft.Template.Dal.EF
{
    public class PlayerSoftContext : DbContext
    {
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerPhone> PlayerPhones { get; set; }

        public PlayerSoftContext(DbContextOptions<PlayerSoftContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlayerConfig());
        }
    }
}
