using System;
using System.Threading.Tasks;
using PlayerSoft.Template.Bll.Models;

namespace PlayerSoft.Template.Bll.Contracts
{
    public interface IPlayerService
    {
        Task<Player> CreatePlayer(Player player);
        Task<Player> GetPlayer(Guid playerId);
    }
}
