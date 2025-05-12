using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
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
                .FirstOrDefaultAsync(x => x.Id == id && x.Ativo == 1);
        }

        public async Task<bool> Atualizar(Usuarios usuario)
        {
            _context.Usuarios.Update(usuario);
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }

}
