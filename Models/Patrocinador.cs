namespace AspCore04.Models{
    public class Patrocinador{
        public int PatrocinadorId { get; set; }

        public string  Nome { get; set; }

        public string Telefone { get; set; }

        public PatrocinadorEvento PatrocinadorEventoVirtual {get; set;}

    }
}