using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCore04.Models.Maps
{
    public class RealizadorMap : IEntityTypeConfiguration<Realizador>
    {
        public void Configure(EntityTypeBuilder<Realizador> builder)
        {
            builder.ToTable("Realizador");

            builder.HasKey(k => k.RealizadorId).HasName("pk_RealizadorId");

            builder.Property(p => p.Nome).HasColumnType("varchar(45)").IsRequired();

            builder.Property(p => p.Telefone).HasColumnType("varchar(14)");

            builder.Property(p => p.Email).HasColumnType("varchar(20)").IsRequired();

            //Falta props de naveg

        }
    }
}