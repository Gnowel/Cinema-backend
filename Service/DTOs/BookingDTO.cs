using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class BookingDTO
    {
        public string TicketNumber { get; set; } = null!;
        public int SessionId { get; set; }
        public int SeatId { get; set; }
    }
}
