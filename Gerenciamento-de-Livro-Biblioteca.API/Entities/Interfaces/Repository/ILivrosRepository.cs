using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Livro;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository
{
    public interface ILivrosRepository
    {
        Task<List<Livros>> BuscaTodos();
        Task<Livros> BuscaPorId(Guid id);
    }
}
