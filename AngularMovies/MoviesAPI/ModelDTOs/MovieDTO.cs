using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class MovieDTO
    {
        public int ID { get; set; }
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 Characters.")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Summary { get; set; }

        public string Trailer { get; set; }

        public bool InTheaters { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Poster { get; set; }

        public double AverageVote {  get; set; }

        public int UserVote {  get; set; }

        public List<GenreDTO> Genres { get; set; }
        public List<MovieTheaterDTO> MovieTheaters { get; set; }

        public List<ActorMovieDTO> Actors { get; set; }
    }
}
