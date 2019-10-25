using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspCore04.Models{
    public class Realizador{

        public Realizador()
        {
            Eventos = new HashSet<Evento>();
        }

        public int RealizadorId { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório!")]
        [StringLength(45)]
        [DataType(DataType.Text)]
        public string Nome { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage="Formato inválido!")]
        [StringLength(14)]
        public string Telefone { get; set; }

        [Required(ErrorMessage="Este campo é obrigatório!")]
        [DataType(DataType.EmailAddress, ErrorMessage="Sua inserção está inválida! Observe o formato do email!")]
        public string Email { get; set; }

        public ICollection<Evento> Eventos {get; set;} 
    }
}