using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciamento_de_Livro_Biblioteca.API.Data.Configurations
{
    public class LivrosConfiguration : IEntityTypeConfiguration<Livros>
    {
        public void Configure(EntityTypeBuilder<Livros> builder)
        {
            builder.ToTable("livros");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Titulo)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(u => u.Autor)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.ISBN)
                .IsRequired()
                .HasMaxLength(13);
            builder.Property(u => u.AnoPublicacao);
            builder.Property(u => u.NumeroPaginas);               
            builder.Property(u => u.Editora)
                .IsRequired()
                .HasMaxLength(150);
            builder.Property(u => u.Resumo)
               .IsRequired()
               .HasMaxLength(600);
        }
    }
}
