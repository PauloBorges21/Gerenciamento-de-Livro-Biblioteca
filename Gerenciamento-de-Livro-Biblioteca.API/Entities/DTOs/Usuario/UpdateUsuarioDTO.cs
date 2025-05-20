namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario
{
    public class UpdateUsuarioDTO
    {
        public required Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
    }
}
