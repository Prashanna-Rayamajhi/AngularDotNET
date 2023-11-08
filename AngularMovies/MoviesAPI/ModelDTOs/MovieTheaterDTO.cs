
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class MovieTheaterDTO
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name can only be 50 characters long.")]
        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longtitude { get; set; }
    }
}
