using MoviesAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class GenreCreationDTO
    {
        [Required(ErrorMessage = "Name field is required field.")]
        [StringLength(40)]
        [FirstLetterUppercase]
        public string Name { get; set; }
    }
}
