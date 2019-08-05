namespace AspCore04.Models
{
    public class PatrocinadorEvento{

        public int PatrocinadorValorId {get; set;}
        public decimal ValorPatrocinado {get; set;}
    
        public int EventoId { get; set; }
        public Evento EventoVirtual {get; set;}
        
        public int PatrocinadorId { get; set; }
        public Patrocinador PatrocinadorVirtual {get; set;}
    }
}