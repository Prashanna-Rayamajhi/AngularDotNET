using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class ActorCreationDTO
    {

        [Required]
        [StringLength(70, ErrorMessage = "Name cannot be more than 70 characters long!")]
        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        public IFormFile Picture { get; set; }
    }
}
