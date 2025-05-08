namespace Gerenciamento_de_Livro_Biblioteca.API.Entities
{
    public class Usuarios
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public required string Email { get; set; }
        public required string Perfil { get; set; }
        public required string Senha { get; set; }
        public int Ativo { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
