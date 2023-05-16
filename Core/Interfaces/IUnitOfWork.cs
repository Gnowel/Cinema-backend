using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IMovieRepository Movies { get;}
        public ISessionRepository Sessions { get; }
        public ISeatRepository Seats { get; }
        public IBookingRepository Bookings { get; }
        Task<int> CompletedAsync ();
    }
}
