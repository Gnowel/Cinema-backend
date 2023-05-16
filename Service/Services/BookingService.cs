using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    /// <summary>
    /// Class <c>BookingService</c> service для сущности Booking.
    /// </summary>
    public class BookingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Method <c>BookingTicket</c> метод бронирования билета.
        /// </summary>
        public async Task<bool> BookingTicket(User user, BookingDTO bookingDTO)
        {
            var seat    =   await _unitOfWork.Seats.GetSeatById(bookingDTO.SeatId);
            var session =   await _unitOfWork.Sessions.GetSessionById(bookingDTO.SessionId);

            if (session != null && seat != null) 
            {
                seat.Status = true;
                await _unitOfWork.Seats.Update(seat);

                Booking booking = new Booking();
                booking.Session = session;
                booking.SessionId = session.SessionsId;
                booking.Seat = seat;
                booking.SeatId = seat.SeatId;
                booking.TicketNumber = bookingDTO.TicketNumber;
                booking.User = user;
                booking.UserId = user.Id; 

                await _unitOfWork.Bookings.Add(booking);
                await _unitOfWork.CompletedAsync();
                return true;
            }
            return false;
        }
    }
}
