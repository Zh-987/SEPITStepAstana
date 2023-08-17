using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEPAstanaItStep.Models;

namespace SEPAstanaItStep.Controllers
{
    public class EventController : Controller
    {
        // GET: EventController
        static List<Event> events = new List<Event>();
        public ActionResult Index()
        {
            return View(events);
        }

        public ActionResult  Create() {

            var color = new List<Color> {
                new Color(1, "White",145),
                new Color(2, "Black",545),
                new Color(2, "Red",698),
                new Color(2, "Blue",325),
                new Color(2, "Yellow",798)
            };
            ViewBag.Color = new SelectList(color, "Id", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event myevent)
        {
            //myevent.Id = Guid.NewGuid().ToString();
            events.Add(myevent);

            return RedirectToAction("Index");
        }

        public string Details(int id = 1, string name = "Red", int CodeOfColor= 12345) {
            Color color = new Color(id, name, CodeOfColor );
            return $"{id}. {name}. {CodeOfColor}";  
        }

        public string About() {
            string contentURL = Url.Content("~/lib/jquery/dist/jquery.min.js");
            string actionURL = Url.Action("Index", "Home");      
            return $"{contentURL} \n {actionURL}";
        }

    }
}
