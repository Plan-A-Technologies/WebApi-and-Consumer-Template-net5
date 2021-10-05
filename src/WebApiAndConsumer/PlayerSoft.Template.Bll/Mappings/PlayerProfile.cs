using AutoMapper;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Models;

namespace PlayerSoft.Template.Bll.Mappings
{
    /// <summary>
    /// Player automapper profile.
    /// </summary>
    public class PlayerProfile : Profile
    {
        /// <summary>
        /// .ctor
        /// </summary>
        public PlayerProfile()
        {
            CreateMap<Dal.Entities.Player, Player>();
            CreateMap<Player, Dal.Entities.Player>();
            CreateMap<Dal.Entities.Player, IPlayer>();
            CreateMap<IPlayer, Dal.Entities.Player>();
            CreateMap<Dal.Entities.PlayerPhone, PlayerPhone>();
            CreateMap<PlayerPhone, Dal.Entities.PlayerPhone>();
        }
    }
}
