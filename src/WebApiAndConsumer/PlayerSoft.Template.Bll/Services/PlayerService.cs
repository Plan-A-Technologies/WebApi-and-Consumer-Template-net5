using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayerSoft.Template.Bll.Contracts;
using PlayerSoft.Template.Bll.Models;
using PlayerSoft.Template.Dal.EF;

namespace PlayerSoft.Template.Bll.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly PlayerSoftContext _context;
        private readonly IMapper _mapper;

        public PlayerService(PlayerSoftContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Player> CreatePlayer(Player player)
        {
            var newPlayer = _mapper.Map<Dal.Entities.Player>(player);

            newPlayer.Id = Guid.NewGuid();

            if (newPlayer.Phones != null && newPlayer.Phones.Any())
            {
                foreach (var phone in newPlayer.Phones)
                {
                    phone.Id = Guid.NewGuid();
                }
            }

            await _context.Players.AddAsync(newPlayer);

            await _context.SaveChangesAsync();

            return _mapper.Map<Player>(newPlayer);
        }

        public async Task<Player> GetPlayer(Guid playerId)
        {
            var player = await _context.Players
                .Include(p => p.Phones)
                .Where(p=>p.Id == playerId)
                .FirstOrDefaultAsync();

            return player == null ? null : _mapper.Map<Player>(player);
        }
    }
}
