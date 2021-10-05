using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerSoft.Template.Dal.Entities;

namespace PlayerSoft.Template.Dal.Configs
{
    /// <summary>
    /// Configuration for player entity
    /// </summary>
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        /// <summary>
        /// Configure EntityTypeBuilder
        /// </summary>
        /// <param name="builder">EntityTypeBuilder <see cref="EntityTypeBuilder"/></param>
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasMany(player => player.Phones)
                .WithOne(phone => phone.Player)
                .HasForeignKey(phone => phone.PlayerId);
        }
    }
}
