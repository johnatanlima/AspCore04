using System;
using System.Collections.Generic;

namespace AspCore04.Models{
    public class Evento{
        public int EventoId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Horario { get; set; }

        public int Banner { get; set; }

        public bool Ativo { get; set; }

        public string Gratuito_Pago { get; set; }

        public int RealizadorId {get; set;}
        public Realizador RealizadorVirtual {get; set;}

        public int PatrocinadorEventoId {get; set;}
        public PatrocinadorEvento PatrocinadorEventoVirtual {get; set;} 
    }
}