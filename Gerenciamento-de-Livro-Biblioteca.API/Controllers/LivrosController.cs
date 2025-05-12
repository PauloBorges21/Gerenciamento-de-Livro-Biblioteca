using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Livro_Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Get LivrosController");
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok("Post LivrosController");
        }

        [HttpPut("{id}")]
        public IActionResult Put()
        {
            return Ok("Put LivrosController");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete()
        {
            return Ok("Delete LivrosController");
        }

    }
}
