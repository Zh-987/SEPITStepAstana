using Microsoft.AspNetCore.Mvc.Filters;

namespace SEPAstanaItStep.Filters
{
    public class SimpleResourceFilter : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));
            //throw new NotImplementedException();
        }
    }
}
