using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Livro_Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuario;

        public UsuariosController(
            IUsuarioService usuario
            )
        {
            _usuario = usuario;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok("Hello from UsuarioController");
        }

        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> BuscaPorId(Guid id)
        {
            try
            {
                var usuarioDba = await _usuario.BuscaPorId(id);
                if (usuarioDba != null)
                {
                    return Ok(usuarioDba);
                }
                else
                {
                    return NotFound($"Usuário com o ID {id} não foi encontrado.");
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }

        }

        [HttpGet("{email}/busca-por-email")]
        public async Task<IActionResult> BuscaPorEmail(string email)
        {
            try
            {
                var usuarioDba = await _usuario.VerificaSeUsuarioJaCadastrado(email);
                if (usuarioDba != null)
                {
                    return Ok(usuarioDba);
                }
                else
                {
                    return NotFound($"Usuário com o Email {email} não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateUsuarioDTO usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest("O objeto não pode ser nulo.");

                var usuarioDba = await _usuario.Post(usuario);
                if (usuarioDba == null)
                {
                    return BadRequest("Usuário já cadastrado.");
                }

                return CreatedAtAction(nameof(BuscaPorEmail), new { email = usuario.Email }, usuarioDba);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, UpdateUsuarioDTO usuarioUpdate)
        {
            try
            {
                if (id != usuarioUpdate.Id)
                    return BadRequest("ID na rota não corresponde ao ID no DTO");

                var usuarioDba = await _usuario.Put(usuarioUpdate);
                if (usuarioDba == null)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound($"Usuário com o ID {id} não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var usuarioDba = await _usuario.Delete(id);
                if (usuarioDba != null)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound($"Usuário com o ID {id} não foi encontrado.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }

        }

    }
}
