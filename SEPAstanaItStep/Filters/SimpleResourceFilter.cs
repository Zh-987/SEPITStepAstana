using Microsoft.AspNetCore.Mvc.Filters;

namespace SEPAstanaItStep.Filters
{
    public class SimpleResourceFilter : Attribute, IResourceFilter
    {
        /* int _id;
         string _token;*/
        ILogger _logger;

        public SimpleResourceFilter(/*int id, string token*/ ILoggerFactory loggerFactory) {
            /*  _id = id;
              _token = token;*/
            _logger = loggerFactory.CreateLogger("SimpleResourceFilter");
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            //throw new NotImplementedException();
            _logger.LogInformation($"OnResourceExecuting - {DateTime.Now}");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            _logger.LogInformation($"OnResourceExecuting - {DateTime.Now}");

            /*context.HttpContext.Response.Headers.Add("ID", _id.ToString());
            context.HttpContext.Response.Headers.Add("TOKEN", _token.ToString());*/

            //context.HttpContext.Response.Cookies.Append("LastVisit", DateTime.Now.ToString("dd/MM/yyyy hh-mm-ss"));
            //throw new NotImplementedException();
        }
    }
}
