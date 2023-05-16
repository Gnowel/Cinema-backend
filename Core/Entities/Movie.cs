using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Movie
    {
        public int MovieId { get; set; }

        public string Title { get; set; } = null!;

        public DateTime ReleaseData { get; set; }

        public string Director { get; set; } = null!;

        public TimeSpan Time { get; set; }

        public string Synopsis { get; set; } = null!;

        public byte[] Poster { get; set; } = null!;

        public int AgeRestriction { get; set; }

        public virtual ICollection<Session> Sessions { get; } = new List<Session>();

        public virtual ICollection<Country> Countries { get; set; } = new List<Country>();

        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
    }
}