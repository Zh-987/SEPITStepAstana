using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEPAstanaItStep.Filters;
using SEPAstanaItStep.Models;

namespace SEPAstanaItStep.Controllers
{
    [CustomExectionFilter]
    public class EventController : Controller
    {
        ApplicationContext db;
        public EventController(ApplicationContext context) { 
            db=context;
        }
        // GET: EventController
        static List<Event> events = new List<Event>();

        [DateTimeExecutionFilter]
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
        public IActionResult Create(Event myevent)
        {
            //myevent.Id = Guid.NewGuid().ToString();
             events.Add(myevent);

            return RedirectToAction("Index");
        }

        public ActionResult Create2()
        {
            return View();
        }

        [HttpPost]
        public string Create2(Person person)
        {
            if(person.Age > 110 || person.Age < 0)
            {
                ModelState.AddModelError("Age","Возраст должен находиться в диапазоне от 0 до 110");
            }
            if (person.Name?.Length < 3) {
                ModelState.AddModelError("Name", "Недопустимая длина строки. Имя должно иметь больше 2 символов");
            }
            if (person.Name == "admin" && person.Age == 30) {
                ModelState.AddModelError("", "Некорректные данные");
            }


            if (ModelState.IsValid) //Valid inValid
            {
                return $"{person.Name} - {person.Age}";
            }
            string errorMessages = "";
            foreach (var item in ModelState) {
                // item.Key;
                // item.Value
                if (item.Value.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid) {
                    errorMessages = $"{errorMessages}\n Ошибки для свойства {item.Key}: \n";
                    foreach (var error in item.Value.Errors)
                    {
                        errorMessages = $"{errorMessages}{error.ErrorMessage}";
                    }

                }
             
            }
            return errorMessages;
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

        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckEmail(string email) {
            if (email == "admin@gmail.com" || email == "zhassulan@gmail.com") {
                return Json(false);
            }
            return Json(true);
        }

        public IActionResult details2() {
            Person person = new Person
            {
                Id = 1,
                Name = "Олжас Кудайбергенов",
                Email = "olzhas@gmail.com",
                HomePage = "https://www.google.com",
                Age = 50,
                DateOfBirth = new DateTime(1973,3,2)
            };
            return View(person);
        }

       
        public IActionResult Index7() {
            int x = 0; 
            int y = 8/x;
            return View();
        }
    }
}
