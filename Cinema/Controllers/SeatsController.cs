using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private readonly SeatService _seatService;
        private readonly ILogger<SeatsController> _logger;

        public SeatsController(SeatService seatService, ILogger<SeatsController> logger)
        {
            _seatService = seatService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/seat/session-seats/{id}")]
        public async Task<IActionResult> GetAllSeatsBySessionId(int id)
        {
            var seats = await _seatService.GetAllSeatsBySessionId(id);
            if(seats != null)
            {
                _logger.LogInformation($"GetAllSeatsBySessionId {id} succeeded");
                return Ok(seats);
            }
            else
            {
                _logger.LogInformation($"GetAllSeatsBySessionId {id} failed");
                return BadRequest();
            }
        }
    }
}
