using Microsoft.AspNetCore.Mvc.Filters;

namespace SEPAstanaItStep.Filters
{
    public class GlobalResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("GlobalResourceFilter.OnResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("GlobalResourceFilter.OnResourceExecuting");
        }
    }
}
