
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

            builder.Services.AddDbContext<GerenciamentoDeLivrosBibliotecaContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("ConexaoPadrao")));

            // Chama a extensão para registrar os serviços
            builder.Services.AddApplicationServices(builder.Configuration);

            // Add services to the container.
            builder.Services.AddControllers();



            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();            

            var app = builder.Build();


            // Configure the HTTP request pipeline.
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
