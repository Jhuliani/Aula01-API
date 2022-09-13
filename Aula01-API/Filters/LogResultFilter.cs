using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula01_API.Filters
{
    public class LogResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource LogResultFilter (APÓS) onResourceExecuted"); ;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("Filtro de Resource LogResultFilter (ANTES) onResourceExecuted"); ;
        }
    }
}
