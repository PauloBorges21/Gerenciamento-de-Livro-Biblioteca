namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario
{
    public class CreateUsuarioDTO
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public required string Perfil { get; set; }
    }
}
