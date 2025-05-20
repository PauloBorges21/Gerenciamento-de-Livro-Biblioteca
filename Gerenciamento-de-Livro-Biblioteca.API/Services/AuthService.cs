using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;

namespace Gerenciamento_de_Livro_Biblioteca.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        //private readonly ITokenService _tokenService;
        public AuthService(IUsuarioRepository usuarioRepository) //, ITokenService tokenService)
        {
            _usuarioRepository = usuarioRepository;
            //_tokenService = tokenService;
        }

        public Task<LoginResponse> Authenticate(LoginRequest request)
        {
            throw new NotImplementedException();
        }

        //public async Task<string> Login(LoginRequest loginRequest)
        //{
        //    var usuario = await _usuarioRepository.BuscaPorEmail(loginRequest.Email);
        //    if (usuario == null || !BCrypt.Net.BCrypt.Verify(loginRequest.Password, usuario.Senha))
        //    {
        //        throw new UnauthorizedAccessException("Email ou senha inválidos.");
        //    }
        //    return "Login bem-sucedido!";
        //    //return _tokenService.GenerateToken(usuario);
        //}
    }
  
}
