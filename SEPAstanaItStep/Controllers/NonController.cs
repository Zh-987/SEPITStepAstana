using Microsoft.AspNetCore.Mvc;

namespace SEPAstanaItStep.Controllers
{
    [NonController]
    public class NonController : Controller
    {
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }
    }
}
