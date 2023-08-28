using Microsoft.AspNetCore.Mvc.Filters;

namespace SEPAstanaItStep.Filters
{
    public class SimpleAsyncActionFilte : IAsyncActionFilter
    {
        Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
