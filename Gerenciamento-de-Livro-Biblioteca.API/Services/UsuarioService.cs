using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Gerenciamento_de_Livro_Biblioteca.API.Mappers;
using RT.Comb;

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

        public async Task<UsuariosDTO> Post(CreateUsuarioDTO usuarioPost)
        {
            try
            {
                var existeUsuario = await VerificaSeUsuarioJaCadastrado(usuarioPost.Email);
                if (existeUsuario != null)
                    return null;
                var id = GeraGuid();
                usuarioPost.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioPost.Senha);
                var usuario = new Usuarios
                {   
                    Id = id,
                    Nome = usuarioPost.Nome,
                    Email = usuarioPost.Email,
                    Senha = usuarioPost.Senha,
                    Ativo = 1,
                    Perfil = usuarioPost.Perfil,
                    DataCadastro = DateTime.UtcNow,
                    DataAtualizacao = DateTime.UtcNow
                };

                var result = await _usuarioRepository.Criar(usuario);
                return UsuarioMapper.ToDTO(result);
            }
            catch (Exception)
            {

                throw;
            }

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

        public async Task<UsuariosDTO> Delete(Guid id)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaPorId(id);
                if (usuario == null)
                    return null;
                usuario.Ativo = 0;
                usuario.DataAtualizacao = DateTime.UtcNow;

                var result = await _usuarioRepository.Atualizar(usuario);
                return UsuarioMapper.ToDTO(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<UsuariosDTO> Put(UpdateUsuarioDTO usuarioUpdate)
        {
            try
            {
                var usuario = await _usuarioRepository.BuscaPorId(usuarioUpdate.Id);
                if (usuario == null)
                    return null;
                usuario.Nome = usuarioUpdate.Nome;
                usuario.Email = usuarioUpdate.Email;
                usuario.Senha = usuarioUpdate.Senha;
                usuario.DataAtualizacao = DateTime.UtcNow;

                var result = await _usuarioRepository.Atualizar(usuario);
                return UsuarioMapper.ToDTO(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UsuariosDTO> VerificaSeUsuarioJaCadastrado(string email)
        {
            var usuario = await _usuarioRepository.BuscaPorEmail(email);
            if (usuario != null)
                return UsuarioMapper.ToDTO(usuario);
            return null;
        }

        private Guid GeraGuid()
        {
            var guidProvider = new  SqlCombProvider(new UnixDateTimeStrategy());
            Guid id = guidProvider.Create();

            return id;
        }
    }
}
