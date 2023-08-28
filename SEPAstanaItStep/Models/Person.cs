//using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using SEPAstanaItStep.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Security.Policy;

namespace SEPAstanaItStep.Models
{
    public class Person : IValidatableObject
    {

        // [EmailAddress]  [CreditCard]   [Phone]  [Url]
        public int Id { get; set; }


        //[PersonName(new string[] {"Dulat", "Olzhas", "Yerzat"}, ErrorMessage = "Недопустимое имя")]
        [Display (Name="Имя и Фамилия")]
        public string? Name { get; set; }
        //qwerty6789@gmail.com
        //RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"
        //[EmailAddress(ErrorMessage = "Некорректный адрес")]
        //[Remote(action:"CheckEmail" , controller: "Event", ErrorMessage = "Email уже существует")]
        //[Required(ErrorMessage = "Не указан электронный адрес")]
        [Display(Name = "Электронная почта")]
        public string? Email { get; set; }

        //[Required(ErrorMessage = "Не указан пароль")]
        //[Display(Name = "Пароль")]

        [DataType(DataType.Password)]
        public string? Password { get; set; }

        //[Compare("Password", ErrorMessage = "Пароли не совпадают")]
        //[Display(Name = "Повторите пароль")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }

        //[Range(1,110, ErrorMessage = "Недопустимый возраст")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        [DataType(DataType.Currency)]
        public string? Currency { get; set; }

        [DataType(DataType.CreditCard)]
        public string? CreditCard { get; set; }

        [Display(Name = "Страница")]
        [UIHint("URL")]
        public string? HomePage { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString="{0:dd.MM.yyyy}", ApplyFormatInEditMode =true)]
        public DateTime? DateOfBirth { get; set; } //dd/mm/yyyy HH:MM:SS

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
            var errors = new List<ValidationResult>();
            if (string.IsNullOrWhiteSpace(Name)) {
                errors.Add(new ValidationResult("Введите имя!", new List<string>() { "Name" }));
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                errors.Add(new ValidationResult("Введите электронный адрес!"));
            }
            if (Age < 0 || Age > 120) {
                errors.Add(new ValidationResult("Недопустимый возраст!"));
            }
            return errors;
        }
    }
}
