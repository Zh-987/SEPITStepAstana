using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event myevent)
        {
            //myevent.Id = Guid.NewGuid().ToString();
            events.Add(myevent);

            return RedirectToAction("Index");
        }


    }
}
