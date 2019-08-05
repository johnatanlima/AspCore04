using System;
using System.Collections.Generic;

namespace AspCore04.Models{
    public class Evento{

        public Evento()
        {
            PatrociniosValor = new HashSet<PatrocinadorEvento>();
        }

        public int EventoId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Data { get; set; }
        
        public string BannerUrl { get; set; }

        public string Gratuito_Pago { get; set; }

        //Relacionamento EVENTO-REALIZADOR
        public int RealizadorId {get; set;}
        public Realizador RealizadorVirtual {get; set;}

        //Relacionamento 
        public ICollection<PatrocinadorEvento> PatrociniosValor {get; set;}
    }
}