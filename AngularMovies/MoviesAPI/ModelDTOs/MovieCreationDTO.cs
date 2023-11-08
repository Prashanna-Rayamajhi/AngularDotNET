using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Helper;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class MovieCreationDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Summary { get; set; }

        public string Trailer { get; set; }

        public bool InTheaters { get; set; }

        public DateTime ReleaseDate { get; set; }

        public IFormFile Poster { get; set; }

        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> GenreIDs { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<int>>))]
        public List<int> MovieTheaterIDs { get; set; }
        [ModelBinder(BinderType = typeof(TypeBinder<List<MovieActorCreationDTO>>))]
        public List<MovieActorCreationDTO> MovieActors { get; set; }
    }
}
