using Microsoft.AspNetCore.Mvc;

namespace SEPAstanaItStep.Components
{
    public class UsersListViewComponent : ViewComponent
    {
        List<string> users = new List<string>() { "Kazbek","Arman","Olzhas","Dina","Nurai"};
        public IViewComponentResult Invoke() {
            int number = users.Count;

            if (Request.Query.ContainsKey("number")) {
                int.TryParse(Request.Query["number"], out number);  
            }

            ViewBag.Users = users.Take(number);
            ViewData["Header"] = $"Count of users: {number}";
            return View();
        }
    }
}
