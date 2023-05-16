using Microsoft.AspNetCore.Mvc;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly SessionService _sessionService;
        private readonly ILogger<SeatsController> _logger;


        public SessionsController(SessionService sessionService, ILogger<SeatsController> logger)
        {
            _sessionService = sessionService;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/session/movies-release")]
        public async Task<IActionResult> GetSessionWhereMovieRealese()
        {
            var session = await _sessionService.GetSessionWhereMovieRealese();
            if(session == null)
            {
                _logger.LogInformation($"GetSessionWhereMovieRealese failed");
                return NotFound();
            }
            _logger.LogInformation($"GetSessionWhereMovieRealese succeeded");
            return Ok(session);
        }

        [HttpGet]
        [Route("api/session/today")]
        public async Task<IActionResult> GetSessionToday()
        {
            var session = await _sessionService.GetSessionToday();
            if(session == null)
            {
                _logger.LogInformation($"GetSessionToday failed");
                return NotFound();
            }
            _logger.LogInformation($"GetSessionToday succeeded");
            return Ok(session);
        }

        [HttpGet]
        [Route("api/session/tomorrow")]
        public async Task<IActionResult> GetSessionTomorrow()
        {
            var session = await _sessionService.GetSessionTomorrow();
            if(session == null)
            {
                _logger.LogInformation($"GetSessionTomorrow failed");
                return NotFound();
            }
            _logger.LogInformation($"GetSessionTomorrow succeeded");
            return Ok(session);
        }

        [HttpGet]
        [Route("api/session/sessions-by-movie/{id}")]
        public async Task<IActionResult> GetSessionsByMovieId(int id)
        {
            var session = await _sessionService.GetSessionsByMovieId(id);
            if(session == null)
            {
                _logger.LogInformation($"GetSessionsByMovieId {id} failed");
                return NotFound();
            }
            _logger.LogInformation($"GetSessionsByMovieId {id} succeeded");
            return Ok(session);
        }
        [HttpGet]
        [Route("api/session/session-by-id/{id}")]
        public async Task<IActionResult> GetSessionById(int id)
        {
            var session = await _sessionService.GetSessionById(id);
            if( session == null )
            {
                _logger.LogInformation($"GetSessionById {id} failed");
                return NotFound();
            }
            _logger.LogInformation($"GetSessionById {id} succeeded");
            return Ok(session);
        }
    }
}
