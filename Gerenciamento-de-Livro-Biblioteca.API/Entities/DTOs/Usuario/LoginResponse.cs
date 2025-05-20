namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Usuario
{
    public class LoginResponse
    {
        public string Token { get; set; }
        //public DateTime Expiracao { get; set; }
        public string Email { get; set; }
        public string Perfil { get; set; }

        public LoginResponse(string token, string userEmail, string roles)
        {
            Token = token;
            //Expiracao = expiration;
            Email = userEmail;
            Perfil = roles;
        }
    }
}
