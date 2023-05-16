using AutoMapper;
using Cinema.Models.DTOs;
using Core.Entities;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapperProfile
{
    /// <summary>
    /// Class <c>AutoMapperProfile</c> AutoMapper для DTO и Entity.
    /// </summary>
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        { 
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<BookingDTO, Booking>().ReverseMap();
            CreateMap<SessionDTO, Session>().ReverseMap()
                    .ForMember(dest => dest.Date,
                               opt => opt.AddTransform(src => new DateTime(src.Year, 
                                                                           src.Month,
                                                                           src.Day)));
            CreateMap<MovieDTO, Movie>().ReverseMap();
            CreateMap<SeatDTO, Seat>().ReverseMap();
        }
    }
}
