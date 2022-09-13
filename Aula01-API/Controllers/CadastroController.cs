using APIClientes.Core.Interface;
using APIClientes.Core.Model;
using Aula01_API.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Aula01_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    [TypeFilter(typeof(LogActionFilter))]

    public class CadastroController : ControllerBase
    {

        public IClienteService _clienteService;
        public CadastroController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }


        [HttpPost("/cadastro/cadastrar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(LogCPFActionFilter))]
        public ActionResult<Cliente> AdicionarCadastro(Cliente cadastro)
        {
            if (!_clienteService.PostCadastro(cadastro))
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(AdicionarCadastro), cadastro);
        }

        [HttpGet("/cadastro/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]       
        public ActionResult<IEnumerable<Cliente>> RecuperarCadastro()
        {
            return Ok(_clienteService.GetCadastros());
        }

        [HttpGet("/cadastro/{cpf}/consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult RecuperarCadastro(string cpf)
        {
            var cadastro = _clienteService.GetCadastroCpf(cpf);
            if (cadastro == null)
            {
                return NotFound();
            }
            return Ok(cadastro);

        }

        [HttpPut("/cadastro/{cpf}/alterar")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ServiceFilter(typeof(LogUpdateActionFilter))]
        public ActionResult<Cliente> ModificarCadastro(string cpf, Cliente cadastroNovo)
        {

            if (_clienteService.PutCadastros(cpf, cadastroNovo))
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

            if (!_clienteService.DeleteCadastros(cpf))
            {
                return NotFound();
            }
            
            return NoContent();
        }              
        //teste
    }
}
