using System.ComponentModel.DataAnnotations;

namespace SEPAstanaItStep.Models
{
    public class Event
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Name2 { get; set; }
       
        public string Name3 { get; set; }
    
        public int Age { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
    }

    public enum TimeOfDay {
        [Display(Name="Утро")]
        Morning,
        [Display(Name = "День")]
        Afternoon,
        [Display(Name = "Вечер")]
        Evening,
        [Display(Name = "Ночь")]
        Night
    
    }

    public record class Color(int Id, string Name, int CodeOfColor);

}