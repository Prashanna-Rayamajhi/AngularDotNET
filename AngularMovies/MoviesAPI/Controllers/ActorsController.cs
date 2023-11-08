using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesAPI.Helper;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Models;
using MoviesAPI.Repository;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
    public class ActorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileStorageServie fileStorage;
        private readonly string _containerName = "actors";

        public ActorsController(ApplicationDbContext context, IMapper mapper, IFileStorageServie fileStorage)
        {
            this._context = context;
            this._mapper = mapper;
            this.fileStorage = fileStorage;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> GetAllActors([FromQuery] PaginationDTO pagination )
        {
            var actorsAsQueryable =  _context.Actors.AsQueryable();
            await HttpContext.InsertParametersPaginationInHeader(actorsAsQueryable);

            var actors = await actorsAsQueryable.OrderBy(actor => actor.Name).Paginate(pagination).ToListAsync();    

            var actorsDTO = _mapper.Map<List<ActorDTO>>(actors);

            return Ok(actorsDTO);
            
        }
        //retrieving actor by search field
        [HttpPost("searchByName")]
        public async Task<ActionResult<List<ActorMovieDTO>>> SearchByName([FromBody]string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                return new List<ActorMovieDTO>();
            }
            return Ok(await _context.Actors
                .Where(a => a.Name.Contains(name))
                .OrderBy(a => a.Name)
                .Select(a => new ActorMovieDTO { ID = a.ID, Name = a.Name, Picture = a.Picture })
                .Take(5)
                .ToListAsync());
        }
        //retrieving the single actor
        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDTO>> GetActorByID(int id)
        {
            var actor = await _context.Actors.FindAsync(id);
            if(actor == null)
            {
                return NotFound();
            }
            var actorDTO = _mapper.Map<ActorDTO>(actor);

            return Ok(actorDTO);
        }

        //Adding actor to the db
        [HttpPost]
        public async Task<ActionResult> AddActor([FromForm] ActorCreationDTO actorCreation)
        {
            if(actorCreation == null)
            {
                return BadRequest("Provided information is invalid");
            }
            try
            {
                var actor = _mapper.Map<Actor>(actorCreation);
                if (actorCreation.Picture != null)
                {
                    actor.Picture = await fileStorage.SaveFile(_containerName, actorCreation.Picture);
                }
                _context.Actors.Add(actor);
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                BadRequest(ex.Message);
            }    
           
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Edit(int id, [FromForm] ActorCreationDTO actorCreation)
        {
            var actorToEdit = await _context.Actors.FindAsync(id);
            if( actorToEdit == null) 
            {
                return BadRequest("Unable to process your request. Actor Not Found");
            }
             actorToEdit = _mapper.Map(actorCreation, actorToEdit);
            

            if(actorCreation.Picture != null)
            {
                actorToEdit.Picture = await fileStorage.EditFile(_containerName, actorCreation.Picture, actorToEdit.Picture);
            }
            await _context.SaveChangesAsync();
            return Ok();

        }


        //Delete the Actor
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteActor(int id)
        {
            var actorToDelete = await _context.Actors.FindAsync(id);
            if(actorToDelete == null)
            {
                return BadRequest("Actor couldn't be found!");
            }
            await fileStorage.DeleteFile(actorToDelete.Picture, _containerName);
            _context.Actors.Remove(actorToDelete);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
