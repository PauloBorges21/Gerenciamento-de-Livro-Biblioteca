using Gerenciamento_de_Livro_Biblioteca.API.Converters;
using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Gerenciamento_de_Livro_Biblioteca.API.Data
{
    public class GerenciamentoDeLivrosBibliotecaContext : DbContext
    {
        /// <summary>
        /// Método chamado automaticamente pelo Entity Framework na construção do modelo.
        /// Aqui você pode configurar regras personalizadas para as entidades e propriedades.
        /// </summary>
        /// <param name="modelBuilder">Objeto usado para configurar o modelo (entidades, propriedades, relacionamentos, etc).</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GerenciamentoDeLivrosBibliotecaContext).Assembly);
            //Loop por cada entidade de entidade no modelo(ex Pessoa)
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {

                // Aplica automaticamente o CombGuidValueGenerator
                // Caso a entidade possua uma propriedade chamada "Id" do tipo Guid,
                // o valor será gerado em C# usando COMB GUIDs otimizados para PostgreSQL
                var idProperty = entityType.FindProperty("Id");
                if (idProperty != null && idProperty.ClrType == typeof(Guid))
                {
                    idProperty.SetValueGeneratorFactory((_, __) => new CombGuidValueGenerator());
                }

                // Pega todas as propriedades dessa entidade que são do tipo DateTime (não nullable)
                var dateTimeProperties = entityType.ClrType.GetProperties()
                    .Where(p => p.PropertyType == typeof(DateTime) || p.PropertyType == typeof(DateTime?));

                foreach (var property in dateTimeProperties)
                {
                    // Aplica o conversor UtcDateTimeConverter, garantindo que as datas sejam salvas/convertidas em UTC
                    modelBuilder.Entity(entityType.ClrType)  // Obtém a entidade com base no tipo CLR (ex: typeof(Entidade))
                        .Property(property.Name)            // Acessa a propriedade DateTime específica
                        .HasConversion(new UtcDateTimeConverter()); // Aplica o conversor personalizado
                }

            }

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("Usuarios"); 
                entity.Property(p => p.Id).HasColumnName("Id");
                entity.Property(p => p.Nome).HasColumnName("Nome");
                entity.Property(p => p.Email).HasColumnName("Email");
                entity.Property(p => p.Perfil).HasColumnName("Perfil");
                entity.Property(p => p.Ativo).HasColumnName("Ativo");
                entity.Property(p => p.DataCadastro).HasColumnName("DataCadastro");
                entity.Property(p => p.DataAtualizacao).HasColumnName("DataAtualizacao");
                entity.Property(p => p.Senha).HasColumnName("Senha");

            });

            modelBuilder.Entity<Livros>(entity =>
            {
                entity.ToTable("Livros"); 
                entity.Property(p => p.Id).HasColumnName("Id");
                entity.Property(p => p.Titulo).HasColumnName("Titulo");
                entity.Property(p => p.Autor).HasColumnName("Autor");
                entity.Property(p => p.ISBN).HasColumnName("ISBN");
                entity.Property(p => p.AnoPublicacao).HasColumnName("AnoPublicacao");
                entity.Property(p => p.DataCadastro).HasColumnName("DataCadastro");
                entity.Property(p => p.Editora).HasColumnName("Editora");
                entity.Property(p => p.NumeroPaginas).HasColumnName("NumeroPaginas");
                entity.Property(p => p.Resumo).HasColumnName("Resumo");
                entity.Property(p => p.Ativo).HasColumnName("Ativo");
                entity.Property(p => p.DataCadastro).HasColumnName("DataCadastro");
            });

            // Chama o método base para garantir que outras configurações padrão sejam aplicadas
            base.OnModelCreating(modelBuilder);
        }

        // No método OnConfiguring do seu DbContext
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var envConnStr = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            //if (!string.IsNullOrEmpty(envConnStr))
            //{
            //    optionsBuilder.UseNpgsql(envConnStr);
            //}

            if (!optionsBuilder.IsConfigured)
            {
                var isDocker = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Docker";
                var connStr = isDocker
                    ? Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                    : "Host=localhost;Port=5432;Database=DbGerenciamentoDeLivros;Username=postgres;Password=1234";

                optionsBuilder.UseNpgsql(connStr);
            }
        }

        public GerenciamentoDeLivrosBibliotecaContext(DbContextOptions<GerenciamentoDeLivrosBibliotecaContext> options)
            : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Livros> Livros { get; set; }
    }
}
