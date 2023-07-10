using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEPAstanaItStep.Models;
using System;
using System.Diagnostics;
using System.Diagnostics.Contracts;

namespace SEPAstanaItStep.Controllers
{
    public class HomeController : Controller   //ControllerContext   ,  HttpContext,  ActionDescriptor, ModelState,  RouteData 
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
            return RedirectToRoute("default", new { controller = "Home", action = "", userid = "", username = "" };
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

    }

    public record class Error(string Message);
    public record class User(int UserID, string UserName);
}