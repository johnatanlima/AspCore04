using AspCore04.Models;
using AspCore04.Models.Maps;
using Microsoft.EntityFrameworkCore;

namespace AspCore04.Data{
    public class EventoDbContext : DbContext
    {
        public EventoDbContext(DbContextOptions<EventoDbContext> options) : base(options)
        {

        }

        public DbSet<Evento> Eventos {get; set;}
        public DbSet<Realizador> Realizadores {get; set;}
        public DbSet<Patrocinador> Patrocinadores {get; set;}
        public DbSet<PatrocinadorEvento> PatrocinadorEventos {get; set;}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RealizadorMap());
            builder.ApplyConfiguration(new EventoMap());
            builder.ApplyConfiguration(new PatrocinadorMap());
            builder.ApplyConfiguration(new PatrocinadorEventoMap());
        } 
    }
}