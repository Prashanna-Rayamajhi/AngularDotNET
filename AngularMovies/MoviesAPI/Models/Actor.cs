using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Actor
    {
        public int ID { get; set; }

        [Required]
        [StringLength(70, ErrorMessage ="Name cannot be more than 70 characters long!")]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public string Biography { get; set; }

        public string Picture { get; set; }
    }
}
