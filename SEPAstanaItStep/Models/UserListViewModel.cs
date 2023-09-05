using Microsoft.AspNetCore.Mvc.Rendering;
using SEPAstanaItStep.Areas.Account.Models;

namespace SEPAstanaItStep.Models
{
    public class UserListViewModel
    {
        public UserListViewModel(List<Company> companys, int company, string name) {
            companys.Insert(0, new Company { name = "All", id = 0 });
            companies = new SelectList(companys, "id", "name", company);
            SelectedCompany = company;
            Name = name;
        }
        //public IEnumerable<Users> user { get; set; } = new List<Users>();
        public int SelectedCompany { get; }
       public SelectList companies { get; }
        //public SelectList companies { get; set; } = new SelectList(new List<Company>(), "id", "name");
        public string? Name { get; set; }
       

       /* public UserListViewModel(PageViewModel viewModel) {
       /* public UserListViewModel(PageViewModel viewModel) {
           // user = u;
            //companies = c;
            PageViewModel = viewModel;
        }*/
    }
}
