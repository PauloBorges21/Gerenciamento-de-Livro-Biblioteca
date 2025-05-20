namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario
{
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
