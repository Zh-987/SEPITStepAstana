namespace SEPAstanaItStep.Areas.Account.ViewModels
{
    public class CompanyModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CompanyModel(int id, string name) {
            Id = id;
            Name = name;
        }
    }
}
