using Gerenciamento_de_Livro_Biblioteca.API.Data.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Repository;
using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Gerenciamento_de_Livro_Biblioteca.API.Services;

namespace Gerenciamento_de_Livro_Biblioteca.API.Presentation.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            // Add application services here

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
