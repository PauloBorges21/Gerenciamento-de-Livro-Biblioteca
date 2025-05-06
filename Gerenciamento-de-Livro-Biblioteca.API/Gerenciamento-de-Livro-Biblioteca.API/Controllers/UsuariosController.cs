using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Livro_Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from UsuarioController");
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
        public IActionResult Delete()
        {
            return Ok("Hello from DeletarUsuario");
        }

    }
}
