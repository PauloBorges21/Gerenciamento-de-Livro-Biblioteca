
namespace Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuarios> BuscaPorId(Guid id);
        Task<Usuarios> Atualizar(Usuarios usuario);
        //Task<bool> BuscaPorEmail(string email);
        Task<Usuarios> Criar(Usuarios usuario);
        Task<Usuarios> BuscaPorEmail(string email);
    }
}
