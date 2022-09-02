using Aula01_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01_API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class CadastroController : ControllerBase
    {
        private static List<Cadastro> cadastros = new List<Cadastro>();

        [HttpPost]
        public ActionResult<Cadastro> AdicionarCadastro(Cadastro cadastro)
        {
            cadastros.Add(cadastro);
            return CreatedAtAction(nameof(RecuperarCadastro),new { CPF = cadastro.CPF }, cadastro);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Cadastro>> RecuperarCadastro()
        {
            if (cadastros is null)
            {
                return NotFound("Cadastros não encontrados...");
            }
            return cadastros;
        }

        [HttpGet("/{cpf}")]
        public IActionResult RecuperarCadastro(string cpf)
        {
            var cadastro = cadastros.FirstOrDefault(cadastros => cadastros.CPF == cpf);
            if (cadastros is null)
            {
                return NotFound("Cadastros não encontrados...");
            }
            return Ok(cadastro);
        }

        [HttpPut]
        public ActionResult<Cadastro> ModificarCadastro(string cpf, Cadastro cadastroNovo)
        {
            var cadastro = cadastros.FirstOrDefault(cadastros => cadastros.CPF == cpf);
            
            if(cadastro == null)
            {
                return NotFound();
            }
            cadastro.Nome = cadastroNovo.Nome;
            cadastro.Nascimento = cadastroNovo.Nascimento;
            cadastro.Idade = cadastroNovo.Idade;
            return Ok(cadastroNovo);
        }

        [HttpDelete]
        public ActionResult<Cadastro> DeletarCadastro(string cpf)
        {
            var cadastro = cadastros.FirstOrDefault(cadastros => cadastros.CPF == cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            cadastros.Remove(cadastro);
            return Ok(cadastro);
        }

        


        

    }
}
