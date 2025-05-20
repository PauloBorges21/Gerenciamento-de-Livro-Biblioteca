namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario
{
    public class UsuariosDTO
    {
        public string Nome { get; set; }
        public required string Email { get; set; }
        public required string Perfil { get; set; }

    }
}
