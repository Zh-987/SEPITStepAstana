using System.ComponentModel.DataAnnotations;

namespace SEPAstanaItStep.Attributes
{
    public class PersonNameAttribute : ValidationAttribute
    {
        string[] _names;
        public PersonNameAttribute(string[] names) { 
            _names = names;
        }
        public override bool IsValid(object? value) { 
            return value != null && _names.Contains(value);
        }
    }
}
