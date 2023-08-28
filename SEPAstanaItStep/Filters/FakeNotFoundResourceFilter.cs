using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SEPAstanaItStep.Filters
{
    public class FakeNotFoundResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.Result = new ContentResult { Content = "Resource not found" };
        }
    }
}
