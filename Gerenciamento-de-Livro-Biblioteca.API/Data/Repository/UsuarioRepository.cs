using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento_de_Livro_Biblioteca.API.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GerenciamentoDeLivrosBibliotecaContext _context;

        public UsuarioRepository(GerenciamentoDeLivrosBibliotecaContext context)
        {
            _context = context;
        }
        public async Task<Usuarios> BuscaPorId(Guid id)
        {
            return await _context.Usuarios
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == id && x.Ativo == 1);
        }

        public async Task<Usuarios> Atualizar(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync(); // Salva as alterações no banco
            return usuario; // Retorna o usuário atualizado
        }

        public async Task<Usuarios> Criar(Usuarios usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync(); // Salva as alterações no banco
            return usuario; // Retorna o usuário atualizado
        }

        public async Task<Usuarios> BuscaPorEmail(string email)
        {
            return await _context.Usuarios
        .SingleOrDefaultAsync(u => u.Email == email);
        }
    }

}
