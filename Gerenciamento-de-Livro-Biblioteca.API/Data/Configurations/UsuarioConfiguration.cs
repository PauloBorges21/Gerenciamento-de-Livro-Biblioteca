using Gerenciamento_de_Livro_Biblioteca.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gerenciamento_de_Livro_Biblioteca.API.Data.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuarios>
    {
        public void Configure(EntityTypeBuilder<Usuarios> builder)
        {
            builder.ToTable("usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.Perfil)
                .IsRequired();
        }
    }
}
