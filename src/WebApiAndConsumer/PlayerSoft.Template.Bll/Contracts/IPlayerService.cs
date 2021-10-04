using System;
using System.Threading.Tasks;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Models;

namespace PlayerSoft.Template.Bll.Contracts
{
    public interface IPlayerService
    {
        Task<IPlayer> CreatePlayer(IPlayer player);
        Task<IPlayer> GetPlayer(Guid playerId);
    }
}
