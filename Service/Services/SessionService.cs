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
    /// Class <c>SessionService</c> service для сущности Session.
    /// </summary>
    public class SessionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SessionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Method <c>GetSessionWhereMovieRealese</c> метод возвращает все сеансы, где фильмы уже вышли.
        /// </summary>
        public async Task<IEnumerable<SessionDTO>> GetSessionWhereMovieRealese()
        {
            var session = await _unitOfWork.Sessions.GetSessionsWhereMovieRelease();
            return _mapper.Map<IEnumerable<SessionDTO>>(session);
        }
        /// <summary>
        /// Method <c>GetSessionToday</c> метод возвращает сеансы, которые будут сегодня.
        /// </summary>
        public async Task<IEnumerable<SessionDTO>> GetSessionToday()
        {
            var session = await _unitOfWork.Sessions.GetSessionsToday();
            return _mapper.Map<IEnumerable<SessionDTO>>(session);
        }
        /// <summary>
        /// Method <c>GetSessionTomorrow</c> метод возвращает сеансы, которые будут завтра.
        /// </summary>
        public async Task<IEnumerable<SessionDTO>> GetSessionTomorrow()
        {
            var session = await _unitOfWork.Sessions.GetSessionsTomorrow();
            return _mapper.Map<IEnumerable<SessionDTO>>(session);
        }
        /// <summary>
        /// Method <c>GetSessionTomorrow</c> метод возвращает сеансы фильма.
        /// </summary>
        public async Task<IEnumerable<SessionDTO>> GetSessionsByMovieId(int movieId)
        {
            var session = await _unitOfWork.Sessions.GetSessionsByMovieId(movieId);
            return _mapper.Map<IEnumerable<SessionDTO>>(session);
        }
        /// <summary>
        /// Method <c>GetSessionTomorrow</c> метод возвращает сеанс пл id.
        /// </summary>
        public async Task<SessionDTO> GetSessionById(int id)
        {
            var session = await _unitOfWork.Sessions.GetSessionById(id);
            return _mapper.Map<SessionDTO>(session);
        }
    }
}
