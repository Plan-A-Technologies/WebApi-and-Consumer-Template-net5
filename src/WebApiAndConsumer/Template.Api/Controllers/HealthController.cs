using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Bll.Services.Abstractions;

namespace Template.Api.Controllers
{
    /// <summary>
    /// The player controller.
    /// </summary>
    [Route("health")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        private readonly IDbInitService _dbInitService;

        /// <summary>
        /// .ctor
        /// </summary>
        /// <param name="dbInitService">DB init service.</param>
        public HealthController(IDbInitService dbInitService)
        {
            _dbInitService = dbInitService ?? throw new ArgumentNullException(nameof(dbInitService));
        }

        /// <summary>
        /// Checking health API.
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
#pragma warning disable 1998
        public async Task<IActionResult> Get()
#pragma warning restore 1998
        {
            return Ok();
        }

        /// <summary>
        /// Checking health DB.
        /// </summary>
        /// <response code="200">Ok</response>
        [HttpGet("db")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetHealthDb()
        {
            return Ok(await _dbInitService.CheckConnection());
        }
    }
}
