using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlayerSoft.Template.Dal.Entities;

namespace PlayerSoft.Template.Dal.Configs
{
    public class PlayerConfig : IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {
            builder
                .HasMany(player => player.Phones)
                .WithOne(phone => phone.Player)
                .HasForeignKey(phone => phone.PlayerId);
        }
    }
}
