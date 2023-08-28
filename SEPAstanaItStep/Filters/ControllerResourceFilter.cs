using Microsoft.AspNetCore.Mvc.Filters;

namespace SEPAstanaItStep.Filters
{
    public class ControllerResourceFilter : Attribute, IResourceFilter, IOrderedFilter
    {
        public ControllerResourceFilter(int order) => Order = order;
            public int Order { get; }
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("ControllerResourceFilter.OnResourceExecuted");
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("ControllerResourceFilter.OnResourceExecuting");
        }
    }
}
