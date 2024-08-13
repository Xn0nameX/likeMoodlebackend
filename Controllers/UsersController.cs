using Kyzmav2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Kyzmav2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ourmoodlecontext _context;
        private readonly IConfiguration _configuration;

        public UsersController(ourmoodlecontext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser(UserAuthenticationModel authenticationModel)
        {
            var user = AuthenticateUser(authenticationModel.Username, authenticationModel.Password);

            if (user != null)
            {
                var token = GenerateJwtToken(user);
                return Ok(new { Token = token });
            }

            return Unauthorized();
        }

        private userss AuthenticateUser(string username, string password)
        {

            var user = _context.userss.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        private string GenerateJwtToken(userss user)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Secret"]); 

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString()),
            
                }),
                Expires = DateTime.UtcNow.AddHours(1), 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<userss>>> GetUsers()
        {
            return await _context.userss.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<userss>> GetUser(int id)
        {
            var user = await _context.userss.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<userss>> PostUser(InsertUserModel insertUserModel)
        {
            var user = new userss
            {
                Username = insertUserModel.Username,
                Password = insertUserModel.Password,
                Surname = insertUserModel.Surname,
                Patronymic = insertUserModel.Patronymic,
                DOB = insertUserModel.DOB,
                RoleId = insertUserModel.RoleId,
                GroupId = insertUserModel.GroupId
            };

            _context.userss.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.userss.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.userss.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.userss.Any(e => e.UserId == id);
        }
    }
}