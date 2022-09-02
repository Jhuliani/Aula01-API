using Aula01_API.Models;
using Aula01_API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Aula01_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]

    public class CadastroController : ControllerBase
    {
                
        public CadastroRepository _repositoryCadastro;
        public CadastroController(IConfiguration configuration)
        {            
            _repositoryCadastro = new CadastroRepository(configuration);
        }


        [HttpPost("/cadastro/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> AdicionarCadastro(Cadastro cadastro)
        {
            if (!_repositoryCadastro.InsertCadastros(cadastro))
            {
                return BadRequest();
            }          
           
            return CreatedAtAction(nameof(AdicionarCadastro),cadastro);
        }

        [HttpGet("/cadastro/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Cadastro>> RecuperarCadastro()
        {                       
            return Ok(_repositoryCadastro.GetCadastros());            
        }

        [HttpGet("/cadastro/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RecuperarCadastro(string cpf)
        {
            var cadastro = _repositoryCadastro.GetCadastroCpf(cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            return Ok(cadastro);
            
        }

        [HttpPut("/cadastro/{cpf}/alterar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Cadastro> ModificarCadastro(string cpf, Cadastro cadastroNovo)
        {
                        
            if(_repositoryCadastro.PutCadastros(cpf, cadastroNovo))
            {
                return NotFound();
            }
            
            return NoContent();
        }

        [HttpDelete("/cadastro/{cpf}/deletar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeletarCadastro(string cpf)
        {

            if (!_repositoryCadastro.DeleteCadastros(cpf))
            {
                return NotFound();
            }
            
            return NoContent();
        }              

    }
}
