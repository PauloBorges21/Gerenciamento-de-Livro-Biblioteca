using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Livro_Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var response = await _authService.Authenticate(request);
                if (response != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound($"Usuário não foi encontrado.");
                }

            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }

    }
}
