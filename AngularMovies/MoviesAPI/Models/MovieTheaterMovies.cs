namespace MoviesAPI.Models
{
    public class MovieTheaterMovies
    {
        public int MovieID { get; set; }
        public int MovieTheaterID { get; set; }

        public Movie Movie { get; set; }

        public MovieTheater MovieTheater { get; set; }
    }
}
