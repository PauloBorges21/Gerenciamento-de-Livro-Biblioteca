using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento_de_Livro_Biblioteca.API.Data.Repository
{
    public class LivrosRepository : ILivrosRepository
    {
        private readonly GerenciamentoDeLivrosBibliotecaContext _context;
        public LivrosRepository(GerenciamentoDeLivrosBibliotecaContext context)
        {
            _context = context;
        }

        public async Task<List<Livros>> BuscaTodos()
        {
            try
            {
                return await _context.Livros
                     .AsNoTracking()
                    .ToListAsync();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Livros> BuscaPorId(Guid id)
        {
            try
            {
                return await _context.Livros
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Ativo == 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
