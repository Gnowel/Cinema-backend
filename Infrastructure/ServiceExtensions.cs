using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure
{
    /// <summary>
    /// Class <c>ServiceExtensions</c> класс внедрения зависимостей.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method <c>ConfigureInfrastructureAsync</c> внедряет зависимости.
        /// </summary>
        public static async Task ConfigureInfrastructureAsync(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<CinemaContext>();

            services.AddDbContext<CinemaContext>();

            using (var scope = services.BuildServiceProvider().CreateScope())
            {
                var cinemaContext = scope.ServiceProvider
                                         .GetRequiredService<CinemaContext>();

                await CinemaContextSeed.SeedAsync(cinemaContext);
                await SeatSeed.SeedAsync(cinemaContext);
                await IdentitySeed.CreateUserRoles(scope.ServiceProvider);
            }

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IIdentityService, IdentityService>();
        }
    }
}
