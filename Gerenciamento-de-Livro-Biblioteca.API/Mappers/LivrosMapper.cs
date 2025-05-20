using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Livro;

namespace Gerenciamento_de_Livro_Biblioteca.API.Mappers
{
    public class LivrosMapper
    {
        public static LivrosDTO ToDTO(Livros livros)
        {
            return new LivrosDTO
            {
                Id = livros.Id,
                Titulo = livros.Titulo,
                Autor = livros.Autor,
                ISBN = livros.ISBN,
                AnoPublicacao = livros.AnoPublicacao,
                Editora = livros.Editora,
                NumeroPaginas = livros.NumeroPaginas,
                Resumo = livros.Resumo,
            };
        }


        public static Livros ToEntity(CreateLivrosDTO livros)
        {
            return new Livros
            {
                Titulo = livros.Titulo,
                Autor = livros.Autor,
                ISBN = livros.ISBN,
                AnoPublicacao = livros.AnoPublicacao,
                Editora = livros.Editora,
                NumeroPaginas = livros.NumeroPaginas,
                Resumo = livros.Resumo,
            };
        }
    }
}
