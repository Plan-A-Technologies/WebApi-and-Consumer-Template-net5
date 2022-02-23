using AutoMapper;
using Template.Api.ViewModels;
using Template.Api.ViewModels.Request;
using Template.Api.ViewModels.Response;
using Template.Bll.Dto;
using Template.Shared.DtoContracts;

namespace Template.Api.Mappings
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class PlayerProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerProfile"/> class.
        /// </summary>
        public PlayerProfile()
        {
            CreateMap<IPlayerDto, PlayerResponseViewModel>();
            CreateMap<CreatePlayerRequestViewModel, IPlayerDto>();
        }
    }
}
