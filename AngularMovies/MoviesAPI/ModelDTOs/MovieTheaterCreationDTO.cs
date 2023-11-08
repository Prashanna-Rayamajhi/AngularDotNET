using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class MovieTheaterCreationDTO
    {
        [Required]
        [StringLength(50, ErrorMessage = "Name can only be 50 characters long.")]
        public string Name { get; set; }

        [Range(-90, 90)]
        public double Latitude { get; set; }

        [Range(-180, 180)]
        public double Longtitude { get; set; }
    }
}
