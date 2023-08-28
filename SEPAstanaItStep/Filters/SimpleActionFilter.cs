using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.Filters;
namespace SEPAstanaItStep.Filters
{
    public class SimpleActionFilter : IActionFilter
    {
        
        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
    }
}
