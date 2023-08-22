//using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SEPAstanaItStep.Models
{
    public class Person
    {

        // [EmailAddress]  [CreditCard]   [Phone]  [Url]
        public int Id { get; set; }
              
        [Required (ErrorMessage = "Не указано имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должно быть от 3 до 50 символов")]
        public string? Name { get; set; }  //qwerty6789@gmail.com
        //RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}"
        //[EmailAddress(ErrorMessage = "Некорректный адрес")]
        [Remote(action:"CheckEmail" , controller: "Event", ErrorMessage = "Email уже существует")]
        [Required(ErrorMessage = "Не указан электронный адрес")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string? PasswordConfirm { get; set; }
        [Range(1,110, ErrorMessage = "Недопустимый возраст")]
        public int Age { get; set; }
          
    }
}
