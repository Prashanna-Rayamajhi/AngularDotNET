using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieActor
    {
        public int MovieID { get; set; }
        public int ActorID { get; set; }

        [StringLength(50, ErrorMessage ="Character cannot be longer than 50 Characters.")]
        public string Character { get; set; }

        public int Order { get; set; }
        public Actor Actor { get; set; }

        public Movie Movie { get; set; }
    }
}
