using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Booking
    {
        public int BookingId { get; set; }

        public string UserId { get; set; }

        public int SessionId { get; set; }

        public int SeatId { get; set; }

        public string TicketNumber { get; set; } = null!;

        public virtual Seat Seat { get; set; } = null!;

        public virtual Session Session { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}

