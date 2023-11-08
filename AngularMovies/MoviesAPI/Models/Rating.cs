using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Rating
    {
        public int Id { get; set; }
        [Range(1 ,5)]
        public int Rate { get; set; }

        public int MovieID { get; set; }

        public Movie Movie { get; set; }    
        public string UserID { get; set; }
        public IdentityUser User { get; set; }
    }
}
