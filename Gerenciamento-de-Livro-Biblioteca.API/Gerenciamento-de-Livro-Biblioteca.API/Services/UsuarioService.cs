using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;

namespace Gerenciamento_de_Livro_Biblioteca.API.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(
            IUsuarioRepository usuarioRepository
            )
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<UsuariosDTO> BuscaPorId(Guid id)
        {
            var usuario = await _usuarioRepository.BuscaPorId(id);
            if (usuario == null)
                return null;
            return new UsuariosDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil,
            };
        }
    }
}
