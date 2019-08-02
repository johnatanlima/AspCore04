

using AspCore04.Models;
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
    }
}