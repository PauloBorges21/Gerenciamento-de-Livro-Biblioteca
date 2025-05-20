using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;

namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Authenticate(LoginRequest request);
    }
}
