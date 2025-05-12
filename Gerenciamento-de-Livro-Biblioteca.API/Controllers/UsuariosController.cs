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
            catch (Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Hello from UsuarioController");
        }

        [HttpPut("{id}")]
        public IActionResult Put()
        {
            return Ok("Hello from AtualizarPerfilUsuario");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var usuarioDba = await _usuario.Delete(id);
                if (usuarioDba)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound($"Usuário com o ID {id} não foi encontrado.");
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
