
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> BuscaPorId(Guid id);
    }
}
