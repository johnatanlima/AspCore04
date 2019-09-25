using System.ComponentModel.DataAnnotations;

namespace AspCore04.Models.ViewModels
{
    public class UsuarioViewModel{
        
        [Required(ErrorMessage="Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage="Máx. 45 caracteres!")] 
        public string Nome { get; set; }
     
        [Required(ErrorMessage="Este campo é obrigatório!")]
        public string Sobrenome { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage="Formato de ser xxx@xxx.xxx")]
        [Required(ErrorMessage="Este campo é obrigatório!")]
        public string Email {get; set;}

        [DataType(DataType.Password)]
        public string Senha {get; set;}

    }
} 

