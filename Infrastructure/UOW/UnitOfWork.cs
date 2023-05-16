using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UOW
{
    /// <summary>
    /// Class <c>UnitOfWork</c> паттерн UnitOfWork.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CinemaContext _context;
        public IMovieRepository Movies { get; private set; }
        public ISessionRepository Sessions { get; private set; }
        public ISeatRepository Seats { get; private set; }
        public IBookingRepository Bookings { get; private set; }

        public UnitOfWork(CinemaContext context)
        {
            _context = context;
            Movies = new MovieRepository(context);
            Sessions = new SessionRepository(context);  
            Seats = new SeatRepository(context);
            Bookings = new BookingRepository(context);
        }
        /// <summary>
        /// Method <c>CompletedAsync</c> сохранение в БД.
        /// </summary>
        public async Task<int> CompletedAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Method <c>Dispose</c> освобождение памяти.
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
