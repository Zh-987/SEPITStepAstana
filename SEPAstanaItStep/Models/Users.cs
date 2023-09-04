namespace SEPAstanaItStep.Models
{
    public class Users
    {
        public int id { get; set; }
        public string? name { get; set; }
        public int age { get; set; }
        public string? email { get; set; }
        public int? CompnayId { get; set; }
        public Company? Company { get; set; }

    }

    public class Company { 
        public int id { get; set; } 
        public string? name { get; set; }
        public List<Users> User { get; set; } = new();
    }


    public enum SortState { 
        NameAsc,
        NameDesc,
        AgeAsc,
        AgeDsc,
        EmailAsc,
        EmailDsc,
        CompanyAsc,
        CompanyDsc
    }
}
