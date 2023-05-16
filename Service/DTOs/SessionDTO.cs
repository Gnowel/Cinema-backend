using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class SessionDTO
    {
        public int SessionsId { get; set; }

        public int MovieId { get; set; }

        public int HallId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Time { get; set; }

        public int Price { get; set; }
        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

        public virtual Hall Hall { get; set; } = null!;

        public virtual Movie Movie { get; set; } = null!;
        public virtual ICollection<Seat> Seats { get; } = new List<Seat>();


    }
}
