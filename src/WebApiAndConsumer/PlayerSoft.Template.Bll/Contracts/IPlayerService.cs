using System;
using System.Threading.Tasks;
using PlayerSoft.Contracts.Contracts;

namespace PlayerSoft.Template.Bll.Contracts
{
    public interface IPlayerService
    {
        Task<IPlayer> CreatePlayer(IPlayer player);
        Task<IPlayer> GetPlayer(Guid playerId);
    }
}
