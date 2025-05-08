using Gerenciamento_de_Livro_Biblioteca.API.Entities.Interfaces.Services;
using Gerenciamento_de_Livro_Biblioteca.API.Services;

namespace Gerenciamento_de_Livro_Biblioteca.API.Presentation.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            // Add application services here

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
    }
}
