using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Models;
using MoviesAPI.Repository;
using MoviesAPI.Services.Interface;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class GenreController : ControllerBase
    {
         private readonly IMemoryService _memoryService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(IMemoryService memoryService, ApplicationDbContext context, IMapper mapper)
        {
            this._memoryService = memoryService;
            this._context = context;
            this._mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await _context.Genres.OrderBy(genre => genre.Name).ToListAsync();

            return _mapper.Map<List<GenreDTO>>(genres);
            //return await this._memoryService.GetAllGenres();

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> Get(int id) 
        {
            var genre = await _context.Genres.FindAsync(id);
            if(genre == null)
            {
                return NotFound();
            }

            return _mapper.Map<GenreDTO>(genre);
        }

        [HttpPost]
        public async Task<ActionResult> AddGenre([FromBody] GenreCreationDTO genreCreation)
        {
            if(genreCreation == null)
            {
                return BadRequest();
            }
            //mapping the genreDTO's to Genre object
            var genre = _mapper.Map<Genre>(genreCreation);

            if (_context.Genres.Any(gen => gen.Name.ToUpper() == genre.Name.ToUpper()))
            {
                return BadRequest("The genre was previusly created in database");
            }
            _context.Genres.Add(genre);
            _context.SaveChanges();

            var data =await _context.Genres.FirstOrDefaultAsync(g => g.Name.ToUpper() == genre.Name.ToUpper());

            return  Ok(data);
        }

        //Edit Action
        [HttpPut("{id}")]
        public async Task<ActionResult<GenreDTO>> Edit(int id, [FromBody] GenreCreationDTO genreCreationDTO)
        {
            if(genreCreationDTO == null)
            {
                return BadRequest("Invalid Data");
            }
            var genre = _mapper.Map<Genre>(genreCreationDTO);
            genre.ID = id;

            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<GenreDTO>(genre));
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var genre = await _context.Genres.FindAsync(id);
            if(genre == null)
            {
                return NotFound("Genre Not Found");
            }
            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
