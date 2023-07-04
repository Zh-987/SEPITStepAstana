using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEPAstanaItStep.Models;
using System;
using System.Diagnostics;

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

       /* [HttpGet] 
        public IActionResult GetUsers()
        {
            return View();
        }*/

/*        [HttpPost]      // [HttpPut], [HttpDelete], [HttpPatch], [HttpHead]
        public IActionResult PostUsers()
        {
            return View();
        }
*/
    }

    public record class User(int UserID, string UserName);
}