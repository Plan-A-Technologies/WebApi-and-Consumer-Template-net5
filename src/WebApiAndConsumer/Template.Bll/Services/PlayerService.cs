using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Template.Bll.Dto;
using Template.Bll.Services.Abstractions;
using Template.Dal;
using Template.Dal.Entities;
using Template.Shared.DtoContracts;

namespace Template.Bll.Services
{
    /// <inheritdoc/>
    public class PlayerService : IPlayerService
    {
        /// <summary>
        /// The _context.
        /// </summary>
        private readonly AppDbContext _context;
        /// <summary>
        /// The _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public PlayerService(AppDbContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <inheritdoc/>
        public async Task<IPlayerDto> CreatePlayer(IPlayerDto playerDto)
        {
            var newPlayer = _mapper.Map<Player>(playerDto);

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

            return _mapper.Map<PlayerDto>(newPlayer);
        }

        /// <inheritdoc/>
        public async Task<IPlayerDto> GetPlayer(Guid playerId)
        {
            var player = await _context.Players
                .Include(p => p.Phones)
                .Where(p => p.Id == playerId)
                .FirstOrDefaultAsync();

            return player == null ? null : _mapper.Map<PlayerDto>(player);
        }
    }
}
