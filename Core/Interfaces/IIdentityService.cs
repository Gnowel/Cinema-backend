using Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IIdentityService
    {
        Task<IdentityResult> CreateUserAsync(string email, string password);
        Task<SignInResult> AuthorizeAsync(string email, string password, bool RememberMe);
        Task<User> GetUserAsync(ClaimsPrincipal user);
        Task<string?> GetUserRole(User user);
        Task SignOutAsync();
    }
}
