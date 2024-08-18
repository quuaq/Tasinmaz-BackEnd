using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using tasinmaz_project.Helpers;
using tasinmaz_project.Entities.Concrete;

namespace tasinmaz_project.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public UserController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _authRepository.GetUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Kullanıcıları alırken bir hata oluştu: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var userToDelete = await _authRepository.GetUserById(id);
                if (userToDelete == null)
                {
                    return NotFound("Kullanıcı bulunamadı.");
                }

                // Kullanıcıya ait logları sil
                await _authRepository.DeleteLogsByUserId(id);

                // Kullanıcıyı sil
                await _authRepository.DeleteUser(userToDelete);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Kullanıcıyı silerken bir hata oluştu: {ex.Message}");
            }
        }
    }
}
