using Gerenciamento_de_Livro_Biblioteca.API.Data.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.DTOs.Livro;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Gerenciamento_de_Livro_Biblioteca.API.Mappers;

namespace Gerenciamento_de_Livro_Biblioteca.API.Services
{
    public class LivrosService : ILivrosService
    {
        private readonly ILivrosRepository _livrosRepository;

        public LivrosService(
            ILivrosRepository livrosRepository
            )
        {
            _livrosRepository = livrosRepository;
        }

        public async Task<List<LivrosDTO>> BuscaTodos()
        {
            try
            {
                var livrosDb = await _livrosRepository.BuscaTodos();

                return livrosDb.Select(LivrosMapper.ToDTO).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao buscar todos os livros: {ex.Message}", ex);
            }
        }

        public async Task<LivrosDTO> BuscaPorId(Guid id)
        {
            try
            {
                var livro = await _livrosRepository.BuscaPorId(id);
                if (livro == null)
                    return null;
                return LivrosMapper.ToDTO(livro);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
