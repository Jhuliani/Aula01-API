using APIClientes.Core.Interface;
using APIClientes.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula01_API.Filters
{
    public class LogCPFActionFilter : ActionFilterAttribute
    {
        public IClienteService _cadastroService;
        public LogCPFActionFilter(IClienteService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente cliente = (Cliente)context.ActionArguments["cadastro"];

            if (_cadastroService.GetCadastroCpf(cliente.CPF) != null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status409Conflict);
            }
        }
    }
}
