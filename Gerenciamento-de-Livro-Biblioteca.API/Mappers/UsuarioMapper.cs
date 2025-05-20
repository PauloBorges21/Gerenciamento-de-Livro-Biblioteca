using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario;

namespace Gerenciamento_de_Livro_Biblioteca.API.Mappers
{
    public class UsuarioMapper
    {
        public static UsuariosDTO ToDTO(Usuarios usuario)
        { 
            return new UsuariosDTO
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil
            };
        }


        public static Usuarios ToEntity(CreateUsuarioDTO usuario)
        {
            return new Usuarios
            {
                Nome = usuario.Nome,
                Email = usuario.Email,
                Perfil = usuario.Perfil,
                Senha = usuario.Senha,
            };
        }
    }
}
