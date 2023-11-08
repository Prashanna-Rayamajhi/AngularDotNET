using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MoviesAPI.Helper;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Models;
using MoviesAPI.Repository;
using System.Reflection.Metadata.Ecma335;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class MovieController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageServie _fileStorageServie;
        private readonly UserManager<IdentityUser> userManager;
        private readonly string container = "movies";

        public MovieController(ApplicationDbContext context, IMapper mapper, IFileStorageServie fileStorageServie, UserManager<IdentityUser> userManager)
        {
            this._context = context;
            this._mapper = mapper;
            this._fileStorageServie = fileStorageServie;
            this.userManager = userManager;
        }

        //get request
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<HomeDTO>> Get()
        {
            var top = 10;
            var today = DateTime.Today;

            var upComingReleases = await _context.Movies
                .Where(x => x.ReleaseDate > today)
                .OrderBy(x => x.Name)
                .Take(top)
                .ToListAsync();

            var inTheaters = await _context.Movies
                .Where(x => x.InTheaters)
                .OrderBy(x => x.Name)
                .Take(top)
                .ToListAsync();

            var movies = await _context.Movies
                .OrderBy(x => x.Name)
                .ToListAsync();

            var homeDTO = new HomeDTO
            {
                Movies = _mapper.Map<List<MovieDTO>>(movies),
                FutureReleases = _mapper.Map<List<MovieDTO>>(upComingReleases),
                InTheaters = _mapper.Map<List<MovieDTO>>(inTheaters)
            };
            return Ok(homeDTO);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<MovieDTO>> GetMovieByID(int id)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieGenres).ThenInclude(m => m.Genre)
                .Include(m => m.MoviesTheater).ThenInclude(m => m.MovieTheater)
                .Include(m => m.MovieActors).ThenInclude(m => m.Actor)
                
                .FirstOrDefaultAsync(x => x.ID == id);
            if(movie == null)
            {
                return NotFound();
            }

            //working on rating components

            var averageRating = 0.0;
            var userRating = 0;
            if(_context.Ratings.Any(x => x.MovieID == id))
            {
                averageRating = await _context.Ratings.Where(x => x.MovieID == id)
                    .AverageAsync(x => x.Rate);
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    var email = HttpContext.User.Claims.FirstOrDefault(x => x.Type == "email").Value;

                    var user = await userManager.FindByNameAsync(email);

                    var userID = user.Id;

                    var ratingInDb = await _context.Ratings.FirstOrDefaultAsync(x => x.MovieID == id && x.UserID == userID);
                    if(ratingInDb != null)
                    {
                        userRating = ratingInDb.Rate;
                    }
                }
            }
            var movieDTO = _mapper.Map<MovieDTO>(movie);
            movieDTO.Actors = movieDTO.Actors.OrderBy(x => x.Name).ToList();

            movieDTO.AverageVote = averageRating;
            movieDTO.UserVote = userRating;

            return Ok(movieDTO);
        }

        [HttpGet("PostGet")]
        public async Task<ActionResult<MoviePostGetDTO>> PostGet()
        {
            var genres = await _context.Genres.ToListAsync();
            var genresDTO =  _mapper.Map<List<GenreDTO>>(genres);
            var theaters = await _context.MovieTheaters.ToListAsync();
            var movieTheaterDTO = _mapper.Map<List<MovieTheaterDTO>>(theaters);

            return Ok(new MoviePostGetDTO { Genres = genresDTO, MovieTheaters = movieTheaterDTO });
        }

        [HttpGet("Filter")]
        [AllowAnonymous]
        public async Task<ActionResult<List<MovieDTO>>> Filter([FromQuery] FilterMoviesDTO filterDTO)
        {
            var moviesQueryable = _context.Movies.AsQueryable();

            if (!String.IsNullOrEmpty(filterDTO.Title))
            {
                moviesQueryable = moviesQueryable.Where(x => x.Name.ToUpper().Contains(filterDTO.Title.ToUpper()));
            }
            if (filterDTO.InTheaters)
            {
                moviesQueryable = moviesQueryable.Where(x => x.InTheaters);
            }
            if (filterDTO.UpComingReleases)
            {
                var today = DateTime.Today;
                moviesQueryable = moviesQueryable.Where(x=> x.ReleaseDate > today);
            }
            if(filterDTO.GenreID != 0)
            {
                moviesQueryable = moviesQueryable.Where(x => x.MovieGenres
                .Select(x => x.GenreID)
                .Contains(filterDTO.GenreID));
            }
            await HttpContext.InsertParametersPaginationInHeader(moviesQueryable);
            var movies = await moviesQueryable.OrderBy(x => x.Name).Paginate(filterDTO.PaginationDTO)
                .ToListAsync();

            return Ok(_mapper.Map<List<MovieDTO>>(movies));
        } 

        [HttpPost]
        public async Task<ActionResult> AddMovie([FromForm] MovieCreationDTO movieCreationDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("Not Valid Data");
            }
            var movie = _mapper.Map<Movie>(movieCreationDTO);
            if(movieCreationDTO.Poster  != null)
            {
                movie.Poster = await _fileStorageServie.SaveFile(this.container, movieCreationDTO.Poster);
            }
            AnnotateActorOrder(movie);
            _context.Add(movie);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> EditMovie(int id, [FromForm] MovieCreationDTO movieCreationDTO)
        {
            var movie = await _context.Movies
                .Include(m => m.MovieGenres)
                .Include(m => m.MoviesTheater)
                .Include(m => m.MovieActors)
                .FirstOrDefaultAsync(m => m.ID == id);

            if(movie == null)
            {
                return BadRequest("No Movies found or something bad occured");
            }
            movie = _mapper.Map(movieCreationDTO, movie);
            if(movieCreationDTO.Poster != null) 
            {
                movie.Poster = await _fileStorageServie.EditFile(container, movieCreationDTO.Poster, movie.Poster);
            }
            AnnotateActorOrder(movie);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMovie(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);
            if(movieToDelete != null)
            {
                return NotFound();
            }
            _context.Remove(movieToDelete);

            await _context.SaveChangesAsync();
            await _fileStorageServie.DeleteFile(movieToDelete.Poster, container);
            return NoContent();
        }

        private void AnnotateActorOrder(Movie movie)
        {
            if(movie.MovieActors != null)
            {
                for(int i =0; i < movie.MovieActors.Count(); i++)
                {
                    movie.MovieActors[i].Order = i;
                }
            }
        }
    }
}
