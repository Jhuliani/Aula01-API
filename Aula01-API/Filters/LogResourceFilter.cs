using Microsoft.AspNetCore.Mvc.Filters;

namespace Aula01_API.Filters
{
    public class LogResourceFilter : IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("Filtro de Resource LogResourceFilter (APÓS) onResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            
            Console.WriteLine("Filtro de Resource LogResourceFilter (ANTES) onResourceExecuted");
        }
    }
}
