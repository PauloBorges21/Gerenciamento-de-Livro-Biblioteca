using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Livro;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services
{
    public interface ILivrosService
    {
        Task<List<LivrosDTO>> BuscaTodos();
        Task<LivrosDTO> BuscaPorId(Guid id);
    }
}
