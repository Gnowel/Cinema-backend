using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ISessionRepository : IGenericRepository<Session>
    {
        Task<IEnumerable<Session>> GetSessionsWhereMovieRelease();
        Task<IEnumerable<Session>> GetSessionsTomorrow();
        Task<IEnumerable<Session>> GetSessionsToday();
        Task<IEnumerable<Session>> GetSessionsByMovieId(int movieId);
        Task<Session> GetSessionById(int sessionId); 
    }
}
