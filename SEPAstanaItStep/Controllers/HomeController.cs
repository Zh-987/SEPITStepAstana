using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEPAstanaItStep.Models;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using SEPAstanaItStep.Filters;

namespace SEPAstanaItStep.Controllers
{
    /*  [Route("Study")]
      [Route("{controller}")]*/
    //[ControllerResourceFilter(int.MinValue)]
    [TypeFilter(typeof(SimpleResourceFilter))]
    [ServiceFilter(typeof(SimpleResourceFilter))]
    public class HomeController : Controller   //ControllerContext   ,  HttpContext,  ActionDescriptor, ModelState,  RouteData 
    {
        private readonly ILogger<HomeController> _logger;
        readonly ITimeService _timeService;

        public HomeController(ILogger<HomeController> logger, ITimeService timeService)
        {
            _logger = logger;
            _timeService = timeService;
        }

        public string Index2() {
            return _timeService.Time;
        }

        public string Index3([FromServices] ITimeService timeService)
        {
            return timeService.Time;
        }   
        [FakeNotFoundResourceFilter]
        public string Index4()
        {
            ITimeService? timeService = HttpContext.RequestServices.GetService<ITimeService>();
            return timeService?.Time ?? "Undefined";
        }
        [Route("Main")]  // Home/Main   Study/Main
        [Route("Index6")] // Home/Index6   Study/Main
        //[SimpleResourceFilter(30, "8v9vdfv9sd5v9fdsb5v9er")]
        
        public string Index6(string controller, string action)
        {
            /*var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];*/
            return $"controller: {controller} \t action: {action}";  // View(string? viewName)   ,   View(object? model)   ,  View(string? viewName,object? model)
        }

        //[CheckFilter]
        public string Index7(int id)
        {
            return $"id = {id}";
        }

        // [Route("{controller=Home}/{action=Index}")]   // localhost/Home/Index  or  localhost/Home   or  localhost

        
        public IActionResult Index()
        {
           /* var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];*/
            return View();  // View(string? viewName)   ,   View(object? model)   ,  View(string? viewName,object? model)
        }
        [Route("/{id:int}/{name:maxlength(10)}")]
        public IActionResult Hello(int id, string name) {
            return PartialView();
        }

        public string StringForParameter(User[] user)
        {
            string result = "";
            foreach (var u in user)
            { 
            result = $"{result}{u.UserID} {u.UserName}\n";
            }
                return result;   //localhost/Home/StringForParameter?name=Zein&age=18
        }

        public string StringForParameterAsArray(string[] people)
        {
            string result = "";
            foreach (var person in people) {
                result = $"{result}{person};";
            }
            return result;   //localhost/Home/StringForParameter?name=Zein&age=18
        }

        public string StringForParameterAsDictionary(Dictionary<string, string> items)
        {
            string result = "";
            foreach (var item in items)
            {
                result = $"{result}{item};";
            }
            return result;   //localhost/Home/StringForParameter?name=Zein&age=18
        }

        public string StringforRequest()
        {
            string UserID = Request.Query["UserID"];
            string UserName = Request.Query["UserName"];
            return $"UserID: {UserID}, UserName: {UserName}";   //localhost/Home/StringForParameter?name=Zein&age=18
        }


        public async Task InfoAdmin()
        {
           Response.ContentType = "text/html;charset=utf-8";
           System.Text.StringBuilder table = new("<h3>Request Headers</h3> <table>");

            foreach (var header in Request.Headers) {
                table.Append($"<tr> <td>{header.Key}</td> <td>{header.Value}</td></tr>");
            }
            table.Append("</tabel>");

           await Response.WriteAsync(table.ToString());
        }


        [ActionName("QWERTY")]      // localhost/Home/Privacy x
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task GetUsers()
        {
            string content = @"<form method = 'post'>
             <label>User Name: </label>
             <input name='username'><br/>
             <label>Age: </label>
             <input type='number' name='age'><br/>
             <input type='submit' value= 'Send'/> </form>";
            Response.ContentType= "text/html; charset=utf-8";
            await Response.WriteAsync(content);
        }

        [HttpPost]      // [HttpPut], [HttpDelete], [HttpPatch], [HttpHead]
        public string GetUsers(User user)
        {
            return $"{user.UserID}: {user.UserName}";
        }
        // void  IActionResult 

        public IActionResult ExecuteResultSample() {
            return new HtmlResult("<h1> HELLO IT STEP ASTANA </h1>");
        }


        public IActionResult QQQQQ() {

            return new EmptyResult();

        }

        // ContentResult
        //EmptyResult   
        //NoContentResult 
        //FileResult  
        //FileContentResult  
        //ObjectResult
        //StatusCodeResult
        //UnauthorizedResult
        //NotFoundResult
        //NotFoundObjectResult 
        //BadRequestResult
        //BadRequestObjectResult
        //okResult
        //okObjectResult 
        //CreatedResult 
        //CreatedAtActionResult and CreatedAtRouteResult 
        // AcceptedResult
        // AcceptedAtActionbResult and  AcceptedAtRouteResult
        // JsonResult 
        // ParialViewResult 
        // RediredtResult 
        // RedirectToRouteResult and RedirectToActionResult and RedirectToPageResult
        // LoadRedirectResult 
        // ViewCompanentResult 
        // ViewResult


        public IActionResult ContentExample() {
            return Content("Hello IT STEP");
        }

        public JsonResult JsonExample() {
            return Json("Name");
        }

        public IActionResult JsonResultExample() {
            User user = new User(001, "qwerty");
            var jsonOptions = new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                WriteIndented = true
            };
            return Json(user, jsonOptions);
        }


        public IActionResult RedirecttoActionExample() {
            return Redirect("~/Home/ContentExample");
        }

        public IActionResult RedirecttoRouteExample()
        {
            return Redirect("https://github.com/Zh-987/SEPITStepAstana/tree/main/SEPAstanaItStep/Controllers");
        }
        public IActionResult RedirectPermanentExample() {
            return RedirectPermanent("~/Home/ContentExample");
        }
        public IActionResult RedirectLocalExample()
        {
            return LocalRedirect("~/Home/ContentExample");
            //return LocalRedirectPermanent("~/Home/ContentExample");
        }

        public IActionResult RedirectActionEcxamle()
        {
            return RedirectToAction("JsonResultExample", "Home");
        }

        public IActionResult RedirectActionWithParametersEcxamle()
        {
            return RedirectToAction("JsonResultExample", "Home", new { userid = 001, username = "qwerty"});  // /Home/JsonResultExample?userid=001&username=qwerty
        }

        public IActionResult RedirectRouteEcxamle()
        {
            return RedirectToRoute("default", new { controller = "Home", action = "", userid = "", username = "" });
        }
        public IActionResult StatusCodeResult() {
            return StatusCode(401);
        }

        public IActionResult NOtFoundResult()
        {
            return NotFound("Resource not found");
        }
        public IActionResult UnauthorizedResultExample(int age)
        {
            if (age < 18) return Unauthorized(new Error("Access os denied"));
            return Content("Access is available");
        }
        public IActionResult BadResultExample(string? name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest("Name undefined");
            return Content($"Name: {name}");
        }
             public IActionResult OkResultExample(string? name)
        {
            return Ok("Dont worry, It step students");
        }
        //FileContentResult  VirtualFileResult FileStreamResult   - File()  PhysicalFileResult   -  PysicalFile()
        public IActionResult FileExample() {
            string file_path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files/text.txt");
            //byte[] array = System.IO.File.ReadAllBytes(file_path);
            FileStream fileStream = new FileStream(file_path, FileMode.Open);
            string file_type = "text/plain";
            string file_name = "text.txt";
            //return PhysicalFile(file_path, file_type, file_name);
            //return File(array, file_type, file_name);
            return File(fileStream, file_type, file_name);
        }
        public IActionResult FileVirtualExample()
        {
            return File("Files/text.txt", "application/octet-stream", "hello.txt");
        }

        // OnActionExecuting() OnActionExecuted()  OnActionExecutionAsync() 
        [HttpGet]
        public IActionResult WorkingWithForms() {
            return View();
        }

        [HttpPost]
        public string WorkingWithForms(string username, string password, int age,bool isMarried, string sex, string country,string comment)
        {
            return $"User name: {username} \t Password: {password} \t Age: {age} \t isMarried: {isMarried} \t Sex: {sex} \t Country: {country} \t Comment: {comment}";
        }
        public string Map() {
            var controller = RouteData.Values["controller"];
            var action = RouteData.Values["action"];
            return $"controller: {controller} | action: {action}"; 
                }
        public string Name_age(string name, int age) {
            return $"Name_age page . Name: {name} \t Age: {age}";
        }

    }
    public record class Error(string Message);
    public record class User(int UserID, string UserName);
}