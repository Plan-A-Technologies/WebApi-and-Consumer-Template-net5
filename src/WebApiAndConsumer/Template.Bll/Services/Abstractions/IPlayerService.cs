using System;
using System.Threading.Tasks;
using Template.Shared.DtoContracts;

namespace Template.Bll.Services.Abstractions
{
    /// <summary>
    /// The player service.
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Create player.
        /// </summary>
        /// <param name="playerDto">Player entity.</param>
        /// <returns>Player entity.</returns>
        Task<IPlayerDto> CreatePlayer(IPlayerDto playerDto);

        /// <summary>
        /// Get player by identifier.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Player entity.</returns>
        Task<IPlayerDto> GetPlayerById(Guid playerId);
    }
}
