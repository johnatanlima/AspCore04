using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspCore04.Models{
    public class Evento{

        public Evento()
        {
            PatrociniosValor = new HashSet<PatrocinadorEvento>();
        }

        public int EventoId { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório!")]
        [StringLength(45, ErrorMessage="Você ultrapassou o limite de caracteres.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório!")]
        [StringLength(255, ErrorMessage="Você ultrapassou o limite de caracteres.")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }
        
        [Required(ErrorMessage="Este campo é obrigatório!")]
        [StringLength(64, ErrorMessage="Você ultrapassou o limite de caracteres.")]
        public string BannerUrl { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório!")]
        [StringLength(10, ErrorMessage="Você ultrapassou o limite de caracteres.")]
        [DisplayFormat(DataFormatString="Gratuito/Pago")]
        public string Gratuito_Pago { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataInicio {get; set;} //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        
        [Required(ErrorMessage="Este campo é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }
        
        //Relacionamento EVENTO-REALIZADOR
        public int RealizadorId {get; set;}
        public Realizador RealizadorVirtual {get; set;}

        //Relacionamento 
        public ICollection<PatrocinadorEvento> PatrociniosValor {get; set;}

    }
}
