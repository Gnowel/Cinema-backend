using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs
{
    public class SeatDTO
    {
        public int SeatId { get; set; }

        public int HallId { get; set; }

        public int SessionId { get; set; }

        public int RowNumber { get; set; }

        public int SeatNumber { get; set; }

        public bool Status { get; set; }

        public virtual Hall Hall { get; set; } = null!;

        public virtual Session Session { get; set; } = null!;
    }
}
