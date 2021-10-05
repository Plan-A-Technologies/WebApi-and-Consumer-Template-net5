using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayerSoft.Contracts.Contracts;
using PlayerSoft.Template.Bll.Contracts;
using PlayerSoft.Template.Bll.Models;
using PlayerSoft.Template.Dal.EF;

namespace PlayerSoft.Template.Bll.Services
{
    /// <inheritdoc/>
    public class PlayerService : IPlayerService
    {
        private readonly PlayerSoftContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public PlayerService(PlayerSoftContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<IPlayer> CreatePlayer(IPlayer player)
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

        /// <inheritdoc/>
        public async Task<IPlayer> GetPlayer(Guid playerId)
        {
            var player = await _context.Players
                .Include(p => p.Phones)
                .Where(p=>p.Id == playerId)
                .FirstOrDefaultAsync();

            return player == null ? null : _mapper.Map<Player>(player);
        }
    }
}
