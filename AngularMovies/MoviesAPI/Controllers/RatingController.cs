using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Models;
using MoviesAPI.Repository;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly Microsoft.AspNetCore.Identity.UserManager<IdentityUser> userManager;

        public RatingController(ApplicationDbContext context, IMapper mapper, UserManager<IdentityUser> userManager)
        {
            this._context = context;
            this._mapper = mapper;
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Post([FromBody] RatingDTO ratingDTO)
        {
            //retrieve email
            var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;

            var user = await userManager.FindByNameAsync(email);

            var userID = user.Id;

            var currentRate = _context.Ratings.FirstOrDefault(x => x.MovieID == ratingDTO.MovieID && x.UserID == userID);

            if(currentRate == null)
            {
                var rating = new Rating
                {
                    Rate = ratingDTO.Rate,
                    MovieID = ratingDTO.MovieID,
                    UserID = userID
                };
                _context.Ratings.Add(rating);
            }
            else
            {
                currentRate.Rate = ratingDTO.Rate;
            }
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
