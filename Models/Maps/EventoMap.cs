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

            builder.Property(p => p.Titulo).HasColumnType("varchar(45)").IsRequired();

            builder.Property(p => p.Descricao).HasColumnType("varchar(255)").IsRequired();

            builder.Property(p => p.Gratuito_Pago).HasColumnType("varchar(10)").IsRequired();

            builder.Property(p => p.BannerUrl).HasColumnType("varchar(1024)").HasDefaultValue("~/Imagens/Default.png");
            
            builder.Property(p => p.Data).HasColumnType("datetime");

            //Falta props de naveg

        }
    }
}