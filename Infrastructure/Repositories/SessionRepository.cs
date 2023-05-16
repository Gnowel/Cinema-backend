using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class SessionRepository : GenericRepository<Session>, ISessionRepository
    {
        public SessionRepository(CinemaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Session>> GetSessionsTomorrow()
        {
            return await _dbSet.Where(date => date.Date == DateTime.Now.AddDays(1).Date)
                               .Include(s => s.Movie)
                               .Include(s => s.Hall)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsWhereMovieRelease()
        {
            return await _dbSet.Where(s => s.Movie.ReleaseData <= DateTime.Now)
                               .Include(s => s.Movie)
                               .Include(s => s.Movie.Genres)
                               .GroupBy(s => s.MovieId)
                               .Select(g => g.First())
                               .ToListAsync();
        }
        public async Task<IEnumerable<Session>> GetSessionsToday()
        {
            return await _dbSet.Where(s => s.Date.Date == DateTime.Now.Date)
                               .Include(s => s.Movie)
                               .Include(s => s.Hall)
                               .ToListAsync();
        }

        public async Task<IEnumerable<Session>> GetSessionsByMovieId(int id)
        {
            return await _dbSet.Where(s => s.Date.Date >= DateTime.Now.Date)
                               .Include(s => s.Movie)
                               .Include(s => s.Hall)
                               .Where(s => s.Movie.MovieId == id && s.Movie.ReleaseData.Date <= DateTime.Now.Date)
                               .OrderBy(s => s.Date)
                               .ToListAsync();
        }
        public async Task<Session> GetSessionById(int id)
        {
            return await _dbSet.Where(s => s.SessionsId == id)
                               .Include(s => s.Movie)
                               .Include(s => s.Hall)
                               .FirstAsync();
        }
    }
}
