using System.ComponentModel.DataAnnotations;

namespace Aula01_API.Models
{
    public class Cadastro
    {
        [Required(ErrorMessage = "Campo CPF obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Nascimento obrigatório")]
        public DateTime Nascimento { get; set; }

        public int Idade => DateTime.Now.Year - Nascimento.Year;
    }
}
