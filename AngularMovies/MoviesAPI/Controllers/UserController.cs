using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MoviesAPI.Helper;
using MoviesAPI.ModelDTOs;
using MoviesAPI.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviesAPI.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly IConfiguration configuration;
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public UserController(UserManager<IdentityUser> _userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration,
            ApplicationDbContext context,
            IMapper mapper)
        {
            this.userManager = _userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost("create")]
        public async Task<ActionResult<AuthenticationResponse>> Create([FromBody] UserCredentials credentials)
        {
            var user = new IdentityUser() { Email = credentials.Email, UserName = credentials.Email };
            var result = await userManager.CreateAsync(user, credentials.Password);
            if (result.Succeeded)
            {
                return await BuildToken(credentials);
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticationResponse>> Login([FromBody] UserCredentials credentials)
        {
            var result = await signInManager.PasswordSignInAsync(credentials.Email, credentials.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return await BuildToken(credentials);
            }
            else
            {
                return BadRequest("Incorrect Login Credentials");
            }
        }
        [HttpGet("usersList")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult<List<UserDTO>>> GetAllUsers([FromQuery]PaginationDTO pagination)
        {
            var usersAsQueryable = this.context.Users.AsQueryable();
            HttpContext.InsertParametersPaginationInHeader(usersAsQueryable);

            var users = await usersAsQueryable.OrderBy(x => x.Email).Paginate(pagination).ToListAsync();

            return mapper.Map<List<UserDTO>>(users);
            
        }
        [HttpPost("makeAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult> AddAdmin([FromBody] string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if(user != null)
            {
                userManager.AddToRoleAsync(user, "admin").Wait();
                await userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "admin"));
                return NoContent();
            }
            return BadRequest("Something went wrong!!! Likely user is missing");
        }
        [HttpPost("removeAdmin")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "IsAdmin")]
        public async Task<ActionResult> RemoveAdmin([FromBody] string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                userManager.RemoveClaimAsync(user, new Claim(ClaimTypes.Role, "admin")).Wait();
                userManager.RemoveFromRoleAsync(user, "admin").Wait();
                return NoContent();
            }
            return BadRequest("Something went wrong!!! Likely user is missing");
        }

        private async Task<AuthenticationResponse> BuildToken(UserCredentials credentials)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", credentials.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["KeyJwt"]));

            var user = await userManager.FindByNameAsync(credentials.Email);
            
            var claimValueFromDb = await userManager.GetClaimsAsync(user);
            if(claimValueFromDb != null)
            {
                foreach (var claim in claimValueFromDb)
                {
                    // Split the claim value using the semicolon separator
                    string[] parts = claim.ToString().Split(':');
                    if(parts.Length == 3)
                    {
                        // This will be "http://schemas.microsoft.com/ws/2008/06/identity/claims/role"
                        var uri = new Uri($"{parts[0]}:{parts[1]}");
                        string claimKey = uri.Segments.Last();
                        string claimValue = parts[2].TrimStart();  // This will be "Admin"
                        claims.Add(new Claim(claimKey, claimValue));
                    }
                }
                 

            }

           

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddSeconds(10000);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims, expires: expiration, signingCredentials: creds);

            return new AuthenticationResponse
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration
            };
        }
    }
}
