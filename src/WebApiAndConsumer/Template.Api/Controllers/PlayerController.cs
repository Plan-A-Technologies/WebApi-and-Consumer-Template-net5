using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Bll.Dto;
using Template.Bll.Services.Abstractions;
using Template.Shared.DtoContracts;

namespace Template.Api.Controllers
{
    /// <summary>
    /// The player controller.
    /// </summary>
    [Route("players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="playerService">The player service.</param>
        /// <param name="mapper">The automapper.</param>
        public PlayerController(IPlayerService playerService, IMapper mapper)
        {
            _playerService = playerService ?? throw new ArgumentNullException(nameof(playerService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Get player data.
        /// </summary>
        /// <response code="200">Player</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Player not found</response>
        [HttpGet("{playerId}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IPlayerDto))]
        public async Task<IActionResult> GetPlayer([FromRoute] Guid playerId)
        {
            IPlayerDto playerDto = await _playerService.GetPlayer(playerId);

            if (playerDto == null)
            {
                return NotFound($"Player with Id:{playerId} was not found.");
            }

            return Ok(playerDto);
        }

        /// <summary>
        /// Create player.
        /// </summary>
        /// <response code="201">Player has been created</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(IPlayerDto))]
        public async Task<IActionResult> CreatePlayer([FromBody] PlayerDto request)
        {
            var player = await _playerService.CreatePlayer(request);

            return CreatedAtAction(nameof(GetPlayer), new { playerId = player.Id }, player);
        }
    }
}
