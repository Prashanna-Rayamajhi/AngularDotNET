using MoviesAPI.ModelDTOs;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
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

        public string Poster {  get; set; }

        public List<MovieGenre> MovieGenres { get; set; }

        public List<MovieTheaterMovies> MoviesTheater { get; set; }

        public List<MovieActor> MovieActors { get; set; }
    }
}
