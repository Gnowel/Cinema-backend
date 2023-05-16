using Core.Entities;

namespace Cinema.Models.DTOs
{
    public class MovieDTO
    {
        public int MovieId { get; set; }

        public string Title { get; set; } = null!;

        public string ReleaseData { get; set; }

        public string Director { get; set; } = null!;

        public string Time { get; set; }

        public string Synopsis { get; set; } = null!;

        public string Poster { get; set; } = null!;

        public int AgeRestriction { get; set; }

        public List<string> Countries { get; set; } = new List<string>();
        public List<string> Genres { get; set; } = new List<string>();
    }
}
