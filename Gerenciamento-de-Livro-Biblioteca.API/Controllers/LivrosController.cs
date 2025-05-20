using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Gerenciamento_de_Livro_Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        private readonly ILivrosService _livrosService;

        public LivrosController(
          ILivrosService livrosService
            )
        {
            _livrosService = livrosService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var livrosDb = await _livrosService.BuscaTodos();

                return Ok(livrosDb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }
        }

        [HttpGet("{id}/busca-por-id")]
        public async Task<IActionResult> BuscaPorId(Guid id)
        {
            try
            {
                var livrosDb = await _livrosService.BuscaPorId(id);

                return Ok(livrosDb);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno no servidor: {ex}");
            }
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
