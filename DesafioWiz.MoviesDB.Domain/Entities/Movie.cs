using System;

namespace DesafioWiz.MoviesDB.Domain.Entities
{
    public class Movie
    {
        public string title { get; set; }
        public string original_title { get; set; }
        public DateTime release_date { get; set; }
        public int[] genre_ids { get; set; }
        public Genres genres { get; set; } = new Genres();
        public string overview { get; set; }
    }
}
