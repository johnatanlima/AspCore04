using System.Collections.Generic;

namespace AspCore04.Models{
    public class PatrocinadorEvento{

        public PatrocinadorEvento()
        {
            PatrocinadorEventos = new HashSet<Evento>();
            Patrocinadores = new HashSet<Patrocinador>();
        }

        public int PatrocinadorValorId {get; set;}
        public int EventoId { get; set; }
        public int PatrocinadorId { get; set; }
        public decimal ValorPatrocinado { get; set; }

        public ICollection<Evento> PatrocinadorEventos{get; set;}
        public ICollection<Patrocinador> Patrocinadores {get; set;}

    }
}