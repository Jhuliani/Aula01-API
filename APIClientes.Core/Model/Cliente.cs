using System.ComponentModel.DataAnnotations;

namespace APIClientes.Core.Model
{
    public class Cliente
    {
        [Required(ErrorMessage = "Campo CPF obrigatório")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório")]
        [MaxLength(200)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Nascimento obrigatório")]
        public DateTime DataNascimento { get; set; }
        
        public int Idade => DateTime.Now.Year - DataNascimento.Year;
    }
}
