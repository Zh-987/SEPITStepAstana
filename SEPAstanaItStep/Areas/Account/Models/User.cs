namespace SEPAstanaItStep.Areas.Account.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Company Work { get; set; }
        public User(int id, string name, int age, Company company ) { 
            Id = id;
            Name = name;
            Age = age;
            Work = company;
        }
    }
}
