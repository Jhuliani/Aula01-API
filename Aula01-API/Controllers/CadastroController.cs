using Aula01_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula01_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]

    public class CadastroController : ControllerBase
    {
        private static List<Cadastro> cadastros = new List<Cadastro>();

        [HttpPost("/cadastro/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AdicionarCadastro(Cadastro cadastro)
        {
            cadastros.Add(cadastro);
            return CreatedAtAction(nameof(RecuperarCadastro),new { CPF = cadastro.CPF }, cadastro);
        }

        [HttpGet("/cadastro/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Cadastro>> RecuperarCadastro()
        {
            if (cadastros is null)
            {
                return NotFound("Cadastros não encontrados...");
            }
            return cadastros;
        }

        [HttpGet("/cadastro/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperarCadastro(string cpf)
        {
            var cadastro = cadastros.FirstOrDefault(cadastros => cadastros.CPF == cpf);
            if (cadastros is null)
            {
                return NotFound("Cadastros não encontrados...");
            }
            return Ok(cadastro);
        }

        [HttpPut("/cadastro/{cpf}/alterar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> ModificarCadastro(string cpf, Cadastro cadastroNovo)
        {
            var cadastro = cadastros.FirstOrDefault(cadastros => cadastros.CPF == cpf);
            
            if(cadastro == null)
            {
                return NotFound();
            }
            cadastro.Nome = cadastroNovo.Nome;
            cadastro.Nascimento = cadastroNovo.Nascimento;            
            return Ok(cadastroNovo);
        }

        [HttpDelete("/cadastro/{cpf}/deletar")]
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
