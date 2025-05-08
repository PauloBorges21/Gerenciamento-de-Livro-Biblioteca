
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> BuscaPorId(Guid id);
    }
}
