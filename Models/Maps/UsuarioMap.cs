using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCore04.Models.Maps
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(p => p.UsuarioId).HasName("pk_UsuarioId");

            builder.Property(p => p.Nome).HasColumnType("varchar(45)").IsRequired();

            builder.Property(p => p.Sobrenome).HasColumnType("varchar(45)").IsRequired();

            builder.Property(p => p.Email).HasColumnType("varchar(30)").IsRequired();

            builder.Property(p => p.Senha).HasColumnType("varchar(45)").IsRequired();

            //Props de Navegação e Relacionamentos
            //Geradas automaticamente pelo EF Core

        }
    }
}