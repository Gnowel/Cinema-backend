using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Seat
    {
        public int SeatId { get; set; }

        public int HallId { get; set; }

        public int SessionId { get; set; }

        public int RowNumber { get; set; }

        public int SeatNumber { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; } = new List<Booking>();

        public virtual Hall Hall { get; set; } = null!;

        public virtual Session Session { get; set; } = null!;
    }
}
