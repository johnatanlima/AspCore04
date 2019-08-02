using System.Collections.Generic;

namespace AspCore04.Models{
    public class PatrocinadorEvento{

        public PatrocinadorEvento()
        {
            EventosValores = new HashSet<Evento>();
            PatrocinadorValores = new HashSet<Patrocinador>();
        }

        public int PatrocinadorValorId {get; set;}
        public Evento evento { get; set; }
        public Patrocinador patrocinador { get; set; }
        public decimal Valor { get; set; }

        public ICollection<Evento> EventosValores {get; set;}
        public ICollection<Patrocinador> PatrocinadorValores {get; set;}

    }
}