using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tasinmaz_project.Entities.Concrete;
using tasinmaz_project.Entities.DTO_s;
using tasinmaz_project.Helpers;
using Microsoft.Extensions.Configuration;
using System;

namespace tasinmaz_project.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly IAuthRepository _authRepository;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthRepository authRepository, IConfiguration configuration)
        {
            _authRepository = authRepository;
            _configuration = configuration;
        }

 
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] KullaniciForRegisterDTO kullaniciForRegisterDTO)
        {
            if (kullaniciForRegisterDTO == null)
            {
                return BadRequest("Geçersiz kayıt bilgileri.");
            }

            if (await _authRepository.UserExists(kullaniciForRegisterDTO.kullanici_name))
            {
                ModelState.AddModelError("Username", "Username already exists");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Gelen verileri kontrol etmek için log ekleyin
            Console.WriteLine($"Kullanici Adi: {kullaniciForRegisterDTO.kullanici_name}");
            Console.WriteLine($"Rol: {kullaniciForRegisterDTO.Role}");

            var userToCreate = new Kullanici
            {
                kullanici_name = kullaniciForRegisterDTO.kullanici_name,
                role = kullaniciForRegisterDTO.Role
            };

            var createdUser = await _authRepository.Register(userToCreate, kullaniciForRegisterDTO.Password);
            return StatusCode(201, createdUser);
        }


        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] KullaniciForLoginDTO kullaniciForLoginDTO)
        {
            var user = await _authRepository.Login(kullaniciForLoginDTO.Username, kullaniciForLoginDTO.Password);
            if (user == null)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.kullanici_id.ToString()),
                    new Claim(ClaimTypes.Name, user.kullanici_name),
                    new Claim(ClaimTypes.Role, user.role) // Kullanıcı rolü eklendi
                }),

                Expires = System.DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { token = tokenString });
        }
    }
}

