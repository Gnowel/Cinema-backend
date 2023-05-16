using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Service.AutoMapperProfile;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    /// <summary>
    /// Class <c>ServiceExtensions</c> класс внедрения зависимостей.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Method <c>ConfigureService</c> внедряет зависимости.
        /// </summary>
        public static void ConfigureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient(typeof(SessionService), typeof(SessionService));
            services.AddTransient(typeof(SeatService), typeof(SeatService));
            services.AddTransient(typeof(BookingService), typeof(BookingService));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile.AutoMapperProfile());
            });
            services.AddSingleton(config.CreateMapper());
        }
    }
}
