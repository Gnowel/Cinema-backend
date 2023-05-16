using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Hall
    {
        public int HallId { get; set; }

        public int Name { get; set; }

        //public int Capacity { get; set; }

        public virtual ICollection<Seat> Seats { get; } = new List<Seat>();

        public virtual ICollection<Session> Sessions { get; } = new List<Session>();
    }
}