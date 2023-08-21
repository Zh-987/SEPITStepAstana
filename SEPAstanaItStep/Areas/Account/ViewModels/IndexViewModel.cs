using SEPAstanaItStep.Areas.Account.Models;

namespace SEPAstanaItStep.Areas.Account.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<User> User { get; set; } = new List<User>(); 
        public IEnumerable<CompanyModel> Companies { get; set; } = new List<CompanyModel>();
    }
}