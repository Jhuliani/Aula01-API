using APIClientes.Core.Interface;
using APIClientes.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula01_API.Filters
{
    public class LogUpdateActionFilter : IActionFilter
    {
        public IClienteService _cadastroService;
        public LogUpdateActionFilter(IClienteService cadastroService)
        {
            _cadastroService = cadastroService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Cliente cliente = (Cliente)context.ActionArguments["cadastro"];

            if (_cadastroService.GetCadastroCpf(cliente.CPF) == null)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
