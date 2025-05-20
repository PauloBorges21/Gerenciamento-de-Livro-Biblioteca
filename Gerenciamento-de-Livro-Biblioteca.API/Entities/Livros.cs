namespace Gerenciamento_de_Livro_Biblioteca.API.Entities
{
    public class Livros
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int? AnoPublicacao { get; set; }
        public string Editora { get; set; }
        public int NumeroPaginas { get; set; }
        public string Resumo { get; set; }
        public int Ativo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
