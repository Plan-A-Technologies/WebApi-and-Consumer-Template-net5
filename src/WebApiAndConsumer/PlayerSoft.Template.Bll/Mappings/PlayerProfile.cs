using AutoMapper;
using PlayerSoft.Template.Bll.Models;

namespace PlayerSoft.Template.Bll.Mappings
{
    public class PlayerProfile : Profile
    {
        public PlayerProfile()
        {
            CreateMap<Dal.Entities.Player, Player>();
            CreateMap<Player, Dal.Entities.Player>();
            CreateMap<Dal.Entities.PlayerPhone, PlayerPhone>();
            CreateMap<PlayerPhone, Dal.Entities.PlayerPhone>();
        }
    }
}
