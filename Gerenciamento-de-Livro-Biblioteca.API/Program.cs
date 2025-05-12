using Gerenciamento_de_Livro_Biblioteca.API.Data;
using Gerenciamento_de_Livro_Biblioteca.API.Presentation.Extensions;
using Microsoft.EntityFrameworkCore;
namespace Gerenciamento_de_Livro_Biblioteca.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configuração do DbContext
            builder.Services.AddDbContext<GerenciamentoDeLivrosBibliotecaContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao")));

            // Restante da configuração...
            builder.Services.AddApplicationServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Pipeline de configuração...
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}