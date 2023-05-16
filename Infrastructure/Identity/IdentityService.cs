using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    /// <summary>
    /// Class <c>IdentityService</c> service Identity.
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public IdentityService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Method <c>AuthorizeAsync</c> проверка на авторизацию.
        /// </summary>
        public async Task<SignInResult> AuthorizeAsync(string email, string password, bool RememberMe)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, RememberMe, false);


            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);
                IList<string>? roles = await _userManager.GetRolesAsync(user);
                string? userRole = roles.FirstOrDefault();
                return result;
            }

            return result;
        }

        /// <summary>
        /// Method <c>CreateUserAsync</c> регистрация.
        /// </summary>
        public async Task<IdentityResult> CreateUserAsync(string email, string password)
        {
            User user = new ()
            { 
                Email = email, 
                UserName = email
            };
            
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "user");
                await _signInManager.SignInAsync(user, false);
                return result;
            }

            return result;
        }

        /// <summary>
        /// Method <c>GetUserAsync</c> взятие user.
        /// </summary>
        public Task<User> GetUserAsync(ClaimsPrincipal user) => _userManager.GetUserAsync(user);

        /// <summary>
        /// Method <c>GetUserRole</c> взятие role.
        /// </summary>
        public async Task<string?> GetUserRole(User user)
        {
            IList<string> roles = await _userManager.GetRolesAsync(user);
            return roles.FirstOrDefault();
        }

        /// <summary>
        /// Method <c>SignOutAsync</c> выход из аккаунта.
        /// </summary>
        public Task SignOutAsync() => _signInManager.SignOutAsync();
    }
}
