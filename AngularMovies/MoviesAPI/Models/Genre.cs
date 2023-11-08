using MoviesAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Genre
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name field is required field.")]
        [StringLength(40)]
        [FirstLetterUppercase]
        public string Name { get; set; }

    }
}
