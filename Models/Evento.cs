using System;

namespace AspCore04.Models{
    public class Evento{
        public int EventoId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Horario { get; set; }

        public int Banner { get; set; }

        public bool ativo { get; set; }

        public string Disponibilidade { get; set; }
    }
}