using Microsoft.AspNetCore.Mvc;
using SEPAstanaItStep.Areas.Account.Models;
using SEPAstanaItStep.Areas.Account.ViewModels;

namespace SEPAstanaItStep.Areas.Account.Controllers
{
    [Area("Account")]
    public class HomeController : Controller
    {
        // [Route("{area}")]  //localhost/Account     localhost/Account/Home    localhost/Account/Home/Index
        //[Route("{area}/{controller}")]
        // [Route("{area}/{controller}/{action}")]

        List<User> user;
        List<Company> companies;

        public HomeController() {
            Company microsoft = new Company(1, "Microsoft", "USA");
            Company meta = new Company(2, "Meta", "USA");
            Company amazon = new Company(3, "Amazon", "USA");

            companies = new List<Company> { microsoft, meta, amazon };

            user = new List<User> {
            new User(1,"Almas", 30, microsoft),
            new User(2,"Miras", 29, meta),
            new User(3,"Nursultan", 31, amazon),
            new User(4,"Dina", 31,microsoft),
            new User(5,"Dinara", 31,meta),
            new User(6,"Aruna", 31,amazon)
            };
        }

        public IActionResult Index(int? companyId)
        {
            List<CompanyModel> compModels = companies.Select(c=> new CompanyModel(c.Id, c.Name)).ToList();
            compModels.Insert(0, new CompanyModel(0, "All"));

            IndexViewModel viewModel = new() { Companies = compModels, User = user };

            if (companyId != null && companyId > 0) { 
            viewModel.User = user.Where(u => u.Work.Id == companyId);
            }

            return View(viewModel); 
        }

        public string Index2(User usr) {     //  localhost/profile/Index2?name=Miras
            return $"{usr.Name}({usr.Age})";
        }  
        
        // IModelBinder
        // Request.Form["name"]
        // RouteData.Values["name"]
        // Request.Query["name"]   [name of parameter].[name of properties]
        // Areas/Account/Views/Home
    }
}
