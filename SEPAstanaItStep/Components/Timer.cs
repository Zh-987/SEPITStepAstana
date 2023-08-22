using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Html;

namespace SEPAstanaItStep.Components
{
    [ViewComponent]
    public class Timer
    {
        public IViewComponentResult Invoke() {
            //string time = $"Current Time: {DateTime.Now.ToString("HH:mm:ss")}";
            return new HtmlContentViewComponentResult(
                new HtmlString($"<p>Current Time: <b>{DateTime.Now.ToString("HH::mm:ss")}</b> </p>")
                );
        }
    }
}
