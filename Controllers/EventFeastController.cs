using AutoMapper;
using Jose;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskModsen.Data;
using TaskModsen.Entities;
using TaskModsen.Models;


namespace TaskModsen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventFeastController : Controller
    {
        private readonly ApplicationDbContext _db;
        /// <summary>
        ///service that has been use for the configuration of the jwt
        /// </summary>
        public IConfiguration _Configuration { get; set; }
        /// <summary>
        /// service map provided by dependency injection
        /// </summary>
        private IMapper _map;
        public EventFeastController(ApplicationDbContext db , IMapper map, IConfiguration Configuration)
        {
            _db = db;
            _map = map;
            _Configuration = Configuration;
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public async Task<IActionResult> AuthUser([FromBody] User user)
        {
            if(user != null && user.Password != null && user.UserName != null)
            {
                var userData = await GetUser(user.UserName, user.Password);
                var issuer = _Configuration["Jwt:Issuer"];
                var audience = _Configuration["Jwt:Audience"];
                if (user != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub , user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                        new Claim("Id" , user.Id.ToString()),
                        new Claim("UserName" ,user.UserName),
                        new Claim("Password" ,user.Password)

                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        issuer,
                        claims,
                        audience,
                        expires:DateTime.Now.AddMinutes(28),
                        signingCredentials:signIn
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Creditential");
                }
            }
            else
            {
                return BadRequest("Invalid Creditential");
            }
        }
        private async Task<User> GetUser(string userName, string password)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            return Ok(await _db.EventFeasts.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetEventById([FromRoute] Guid id)
        {
            var eventFeast = await _db.EventFeasts.FindAsync(id);
            if (eventFeast == null)
            {
                return NotFound();
            }
            return Ok(eventFeast);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEvent(EventFeastRequest obj)
        {
            var eventFeast = _map.Map<EventFeast>(obj);
            eventFeast.Id = Guid.NewGuid();
            await _db.EventFeasts.AddAsync(eventFeast);
            await _db.SaveChangesAsync();

            return Ok(eventFeast);
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateContacts([FromRoute] Guid id, EventFeastRequest obj)
        {
            var eventFeast =await _db.EventFeasts.FindAsync(id);
            if (eventFeast != null)
            {
                eventFeast = _map.Map<EventFeast>(obj);
                await _db.SaveChangesAsync();
                return Ok(eventFeast);
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact([FromRoute] Guid id)
        {
            var eventFeast = await _db.EventFeasts.FindAsync(id);
            if (eventFeast != null)
            {
                _db.EventFeasts.Remove(eventFeast);
                _db.SaveChanges();
                return Ok(eventFeast);
            }

            return NotFound();
        }
    }
}
    

