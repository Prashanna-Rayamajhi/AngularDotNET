using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Models;
using MoviesAPI.Repository;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class MovieTheaterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MovieTheaterController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MovieTheaterDTO>>> Get()
        {
            var movieTheaters = await _context.MovieTheaters
                .OrderBy(mt => mt.Name)
                .ToListAsync();

            var movieTheatersDTO = _mapper.Map<List<MovieTheaterDTO>>(movieTheaters);

            return Ok(movieTheatersDTO);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<MovieTheaterDTO>> Get(int id)
        {
            var movieTheater = await _context.MovieTheaters.FindAsync(id);

            if(movieTheater == null)
            {
                return NotFound("Movie Theater could not be found!!!");
            }

            var movieTheaterDTO = _mapper.Map<MovieTheaterDTO>(movieTheater);

            return Ok(movieTheaterDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Post(MovieTheaterCreationDTO theaterCreationDTO)
        {
            var movieTheater = _mapper.Map<MovieTheater>(theaterCreationDTO);
            _context.Add(movieTheater);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] MovieTheaterCreationDTO theaterCreationDTO)
        {
            //var movieTheater = await _context.MovieTheaters.FindAsync(id);
            if(theaterCreationDTO == null ) 
            {
                NotFound("Movie Theater couldn't be found!!");

            }

            var movieTheaterEdited = _mapper.Map<MovieTheater>(theaterCreationDTO);
            movieTheaterEdited.ID = id;
            _context.MovieTheaters.Update(movieTheaterEdited);
            await _context.SaveChangesAsync();
            return Ok();

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var theaterToDelete = await _context.MovieTheaters.FindAsync(id);

            if(theaterToDelete == null)
            {
                return NotFound("Couldn't find the theater to delete.");
            }

            _context.Remove(theaterToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
