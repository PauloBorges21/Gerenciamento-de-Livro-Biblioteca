using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Gerenciamento_de_Livro_Biblioteca.API.Mappers;

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
            try
            {
                var usuario = await _usuarioRepository.BuscaPorId(id);
                if (usuario == null)
                    return null;
                return UsuarioMapper.ToDTO(usuario);
            }
            catch (Exception)
            {

                throw;
            }


        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaPorId(id);
                if (usuario == null)
                    return false;
                usuario.Ativo = 0;
                usuario.DataAtualizacao = DateTime.UtcNow;

               return await _usuarioRepository.Atualizar(usuario);
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
