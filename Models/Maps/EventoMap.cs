using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspCore04.Models.Maps
{
    public class EventoMap : IEntityTypeConfiguration<Evento>
    {
        public void Configure(EntityTypeBuilder<Evento> builder)
        {
            builder.ToTable("Evento");

            builder.HasKey(k => k.EventoId).HasName("pk_EventoId");

            builder.Property(p => p.Titulo).HasColumnType("varchar(45)").IsRequired().HasMaxLength(45);

            builder.Property(p => p.Descricao).HasColumnType("varchar(255)").IsRequired().HasMaxLength(255);

            builder.Property(p => p.Gratuito_Pago).HasColumnType("varchar(10)").IsRequired().HasMaxLength(10);

            builder.Property(p => p.BannerUrl).HasColumnType("varchar(64)").HasDefaultValue("~/Imagens/Default.jpg").HasMaxLength(64);
            
            builder.Property(p => p.DataInicio).HasColumnType("DateTime").IsRequired().ValueGeneratedNever();

            builder.Property(p => p.DataFinal).HasColumnType("DateTime").IsRequired().ValueGeneratedNever();

            //Props de Navegação e Relacionamentos
            //Geradas automaticamente pelo EF Core
        }
    }
}