namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Livro
{
    public class CreateLivrosDTO
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int? AnoPublicacao { get; set; }
        public string Editora { get; set; }
        public int NumeroPaginas { get; set; }
        public string Resumo { get; set; }
    }
}
