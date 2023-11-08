using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheater
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name can only be 50 characters long.")]
        public string Name { get; set; }

        public Point Location { get; set; }
    }
}
