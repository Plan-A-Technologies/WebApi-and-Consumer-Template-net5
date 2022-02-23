using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Api.ViewModels.Request;
using Template.Api.ViewModels.Response;
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
        [ProducesResponseType(typeof(PlayerResponseViewModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlayerResponseViewModel))]
        public async Task<IActionResult> GetPlayer([FromRoute] Guid playerId)
        {
            IPlayerDto playerDto = await _playerService.GetPlayerById(playerId);

            if (playerDto == null)
            {
                return NotFound($"Player with Id:{playerId} was not found.");
            }

            return Ok(_mapper.Map<PlayerResponseViewModel>(playerDto));
        }

        /// <summary>
        /// Create player.
        /// </summary>
        /// <response code="201">Player has been created</response>
        /// <response code="400">Bad request</response>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(PlayerResponseViewModel))]
        public async Task<IActionResult> CreatePlayer([FromBody] CreatePlayerRequestViewModel request)
        {
            var playerDto = await _playerService.CreatePlayer(_mapper.Map<IPlayerDto>(request));

            return CreatedAtAction(nameof(GetPlayer), new { playerId = playerDto.Id }, _mapper.Map<PlayerResponseViewModel>(playerDto));
        }
    }
}
