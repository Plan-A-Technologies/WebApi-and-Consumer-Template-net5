using AutoMapper;
using Template.Bll.Dto;
using Template.Dal.Entities;
using Template.Shared.DtoContracts;

namespace Template.Bll.Mappings
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
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerDto, Player>();
            CreateMap<Player, IPlayerDto>();
            CreateMap<IPlayerDto, Player>();
            CreateMap<PlayerPhone, PlayerPhoneDto>();
            CreateMap<PlayerPhoneDto, PlayerPhone>();
        }
    }
}