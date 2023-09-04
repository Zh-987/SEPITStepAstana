using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

            if (!db.companies.Any()) {
                Company google = new Company { name = "google" };
                Company microsoft = new Company { name = "microsoft" };

                Users user1 = new Users { name = "Eldar", Company = google, age = 30, email = "eldar@poshta.kz" };
                Users user2 = new Users { name = "Qalamqas", Company = microsoft, age = 25, email = "qalamqas@poshta.kz" };

                db.companies.AddRange(google, microsoft);
                db.users.AddRange(user1, user2);
                db.SaveChanges();
            }
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
        public async Task<IActionResult> Index2(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<Users> users = db.users.Include(x => x.Company);

            ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDsc : SortState.AgeAsc;
            ViewData["EmailSort"] = sortOrder == SortState.EmailAsc ? SortState.EmailDsc : SortState.EmailAsc;
            ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDsc : SortState.CompanyAsc;

            users = sortOrder switch
            {
                SortState.NameDesc => users.OrderByDescending(s => s.name),
                SortState.AgeAsc => users.OrderBy(s => s.age),
                SortState.AgeDsc => users.OrderByDescending(s => s.age),
                SortState.EmailAsc => users.OrderBy(s => s.email),
                SortState.EmailDsc => users.OrderByDescending(s => s.email),
                SortState.CompanyDsc => users.OrderByDescending(s => s.Company!.name),
                SortState.CompanyAsc => users.OrderBy(s => s.Company!.name),
                SortState.NameAsc=>users.OrderBy(s=>s.name),
            };
            
            return View(await db.users.AsNoTracking().ToListAsync());
        }

        public IActionResult Create3()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create3(Users user)
        {
            //person.Id
            db.users.Add(user);  //insert 
            await db.SaveChangesAsync();
            return RedirectToAction("Index2");
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
                //Id = 1,
                Name = "Олжас Кудайбергенов",
                Email = "olzhas@gmail.com",
                //HomePage = "https://www.google.com",
                Age = 50,
                //DateOfBirth = new DateTime(1973,3,2)
            };
            return View(person);
        }

       
        public IActionResult Index7() {
            int x = 0; 
            int y = 8/x;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int? id) {
            if (id != null) {
                /* Users? user = await db.users.FirstOrDefaultAsync(p => p.id == id);
                 if (user != null) { 
                     db.users.Remove(user);
                     await db.SaveChangesAsync();
                     return RedirectToAction("Index2");
                 }*/

                Users user = new Users { id = id.Value };
                db.Entry(user).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index2");
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id) {
            if (id != null)
            {
                Users? user = await db.users.FirstOrDefaultAsync(p => p.id == id);
                if (user != null) return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Users user)
        {
            db.users.Update(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index2");
        }
    }
}
