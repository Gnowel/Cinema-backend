using AutoMapper;
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
    /// Class <c>SeatService</c> service для сущности Seat.
    /// </summary>
    public class SeatService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SeatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        /// <summary>
        /// Method <c>GetAllSeatsBySessionId</c> метод возвращает все места данного сеанса.
        /// </summary>
        public async Task<IEnumerable<SeatDTO>> GetAllSeatsBySessionId(int id)
        {
            var seat = await _unitOfWork.Seats.GetAllSeatsBySessionId(id);
            return _mapper.Map<IEnumerable<SeatDTO>>(seat);
        }
    }
}
