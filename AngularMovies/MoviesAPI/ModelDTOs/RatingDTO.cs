using Microsoft.AspNetCore.Identity;
using MoviesAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.ModelDTOs
{
    public class RatingDTO
    {
        [Range(1, 5)]
        public int Rate { get; set; }

        public int MovieID { get; set; }

    }

}
