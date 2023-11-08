using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class ActorDTO
    {
        public int ID { get; set; }

        [Required]
        [StringLength(70, ErrorMessage = "Name cannot be more than 70 characters long!")]
        public string Name { get; set; }

        
        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        public string Picture { get; set; }
    }
}
