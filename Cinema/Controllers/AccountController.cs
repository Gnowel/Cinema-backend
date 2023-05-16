using Cinema.Models;
using Cinema.ViewModels;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;

namespace Cinema.Controllers
{
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IIdentityService identityService, ILogger<AccountController> logger)
        {
            _identityService = identityService;
            _logger = logger;
        }

        [HttpPost]
        [Route("api/account/register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.CreateUserAsync(model.Email, model.Password);

                if (result.Succeeded)
                {
                    return Ok(new { message = "Добавлен новый пользователь: " + model.Email });
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    var errorMsg = new
                    {
                        message = "Пользователь не добавлен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Неверные входные данные",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                return Created("", errorMsg);
            }
        }
        
        [HttpPost]
        [Route("api/account/login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _identityService.AuthorizeAsync(model.Email, model.Password, model.RememberMe);
                //await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                
                if (result.Succeeded)
                {
                    _logger.LogInformation($"Login {model.Email} succeeded");
                    return Ok(new { message = "Выполнен вход", userName = model.Email});
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                    var errorMsg = new
                    {
                        message = "Вход не выполнен",
                        error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                    };
                    _logger.LogInformation($"Login {model.Email} failed");
                    return Created("", errorMsg);
                }
            }
            else
            {
                var errorMsg = new
                {
                    message = "Вход не выполнен",
                    error = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage))
                };
                _logger.LogInformation($"Login {model.Email} failed");
                return Created("", errorMsg);
            }
        }
        
        [HttpPost]
        [Route("api/account/logout")]
        public async Task<IActionResult> Logout()
        {
            User user = await GetCurrentUserAsync();
            if (user == null)
            {
                _logger.LogInformation($"Logout failed");
                return Unauthorized(new { message = "Сначала выполните вход" });
            }
            await _identityService.SignOutAsync();
            _logger.LogInformation($"Logout {user.Email} succeeded");
            return Ok(new { message = "Выполнен выход", userName = user.UserName });
        }
        [HttpGet]
        [Route("api/account/isauthenticated")]
        public async Task<IActionResult> IsAuthenticated()
        {
            User user = await GetCurrentUserAsync();
            if (user == null)
            {
                _logger.LogInformation($"IsAuthenticated failed");
                return Unauthorized(new { message = "Вы Гость. Пожалуйста, выполните вход" });
            }
            string? userRole = _identityService.GetUserRole(user).Result;
            _logger.LogInformation($"IsAuthenticated {user.Email} succeeded");
            return Ok(new { message = "Сессия активна", userName = user.UserName, userRole });
        }
        private Task<User> GetCurrentUserAsync() => _identityService.GetUserAsync(HttpContext.User);
    }
}
