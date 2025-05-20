using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services
{
    public interface IUsuarioService
    {
        Task<UsuariosDTO> Post(CreateUsuarioDTO usuario);
        Task<UsuariosDTO> BuscaPorId(Guid id);
        Task<UsuariosDTO> Delete(Guid id);
        Task<UsuariosDTO> Put(UpdateUsuarioDTO usuario);
        Task<UsuariosDTO> VerificaSeUsuarioJaCadastrado(string email);
    }
}
