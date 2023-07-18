namespace SEPAstanaItStep.Areas.Account.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public Company(int id, string name, string country) { 
            Id = id;
            Name = name;
            Country = country;
        }
    }
}
