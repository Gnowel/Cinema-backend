using Cinema.Models;
using Cinema.Models.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.DTOs;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cinema.Controllers
{
    [Produces("application/json")]
    [EnableCors]
    [ApiController]

    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;
        private readonly IIdentityService _identityService;
        private readonly ILogger<BookingController> _logger;


        public BookingController(BookingService bookingService, IIdentityService identityService, ILogger<BookingController> logger)
        {
            _bookingService = bookingService;
            _identityService = identityService;
            _logger = logger;
        }

        /// <summary>
        /// Method <c>BookingTicket</c> метод бронирования билета.
        /// </summary>
        [HttpPost]
        [Route("api/booking/booking-ticket")]
        public async Task<IActionResult> BookingTicket ([FromBody] BookingDTO booking)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            else
            {
                User user = await _identityService.GetUserAsync(HttpContext.User);
                if (user == null)
                {
                    _logger.LogInformation($"BookingTicket failed");
                    return BadRequest(ModelState);
                }
                else
                {
                    await _bookingService.BookingTicket(user, booking);
                    _logger.LogInformation($"BookingTicket {user.Email} succeeded");
                    return Ok();
                }
            }
        }
    }
}
