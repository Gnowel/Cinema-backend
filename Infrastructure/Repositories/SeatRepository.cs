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
    public class SeatRepository : GenericRepository<Seat>, ISeatRepository
    {
        public SeatRepository(CinemaContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Seat>> GetAllSeatsBySessionId(int id)
        {
            return await _dbSet.Where(s => s.Session.SessionsId == id)
                               .ToListAsync();
        }
        public async Task<Seat> GetSeatById(int id)
        {
            return await _dbSet.Where(s => s.SeatId == id)
                               .FirstAsync();
        }
    }
}
