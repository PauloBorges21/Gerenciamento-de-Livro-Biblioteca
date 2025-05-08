using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuariosDTO> BuscaPorId(Guid id);        
    }
}
