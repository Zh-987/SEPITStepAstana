using Microsoft.AspNetCore.Mvc;

namespace SEPAstanaItStep.Controllers
{
    public class Home2Controller : LogBaseController
    {
        public string Index()
        {
            return "Hello It Step";
        }

        public IActionResult Main() {
            ViewData["Message"] = "Hello It Step from Controller of Home2";
            ViewBag.Message2 = "Kazakhstan Astana";
            ViewBag.People = new List<string> { "Talgat", "Arman", "Andrey" };

            var people = new List<string> { "Akerke", "Balzhan", "Indira" };
            return View(people);
        }

        // ViewData  ViewBag   Модель представления
    }
}
