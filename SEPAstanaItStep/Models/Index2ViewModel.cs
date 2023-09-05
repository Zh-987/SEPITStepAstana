namespace SEPAstanaItStep.Models
{
    public class Index2ViewModel
    {
        public IEnumerable<Users> users { get; }
        public UserListViewModel UserListViewModel { get; }
        public PageViewModel PageViewModel { get; }

        public Index2ViewModel(IEnumerable<Users> user, UserListViewModel userListViewModel, PageViewModel pageViewModel)
        {
            users = user;
            UserListViewModel = userListViewModel;
            PageViewModel = pageViewModel;
        }
    }
}
