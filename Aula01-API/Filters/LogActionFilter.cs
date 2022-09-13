using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Aula01_API.Filters
{
    public class LogActionFilter : IActionFilter
    {
        Stopwatch stopwatch = new Stopwatch();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            stopwatch.Stop();
            Console.WriteLine($"Tempo decorrido: {stopwatch.Elapsed.Milliseconds} ms");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            stopwatch.Start();
        }
    }
}
