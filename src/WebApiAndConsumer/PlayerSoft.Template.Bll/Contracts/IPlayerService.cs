using System;
using System.Threading.Tasks;
using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Template.Bll.Contracts
{
    /// <summary>
    /// The player service.
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Create player.
        /// </summary>
        /// <param name="player">Player entity.</param>
        /// <returns>Player entity.</returns>
        Task<IPlayer> CreatePlayer(IPlayer player);

        /// <summary>
        /// Get player by identifier.
        /// </summary>
        /// <param name="playerId"></param>
        /// <returns>Player entity.</returns>
        Task<IPlayer> GetPlayer(Guid playerId);
    }
}
