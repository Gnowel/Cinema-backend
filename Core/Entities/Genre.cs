using System;
using System.Collections.Generic;

namespace Core.Entities
{
    public partial class Genre
    {
        public int GenreId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
    }
}