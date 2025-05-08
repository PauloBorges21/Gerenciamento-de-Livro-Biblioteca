using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

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
