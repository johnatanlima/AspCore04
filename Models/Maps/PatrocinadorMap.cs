using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCore04.Models.Maps
{
    public class PatrocinadorMap : IEntityTypeConfiguration<Patrocinador>
    {
        public void Configure(EntityTypeBuilder<Patrocinador> builder)
        {
            builder.ToTable("Patrocinador");

            builder.HasKey(k => k.PatrocinadorId).HasName("pk_PatrocinadorId");

            builder.Property(p => p.Nome).HasColumnType("varchar(45)").IsRequired();

            builder.Property(p => p.Telefone).HasColumnType("varchar(14)");

            //falta props de nav
        }
    }
}