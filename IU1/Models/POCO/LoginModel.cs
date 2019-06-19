using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IU1.Models
{
  public class LoginModel
  {

    [Required(ErrorMessage = "Du måste fylla i ett användarnamn")]
    [Display(Name = "Skriv ett användarnamn")]
    public String Name { get; set; }

    [UIHint("password")]
    [Required(ErrorMessage = "Du måste fylla i ett lösenord")]
    [Display(Name = "Skriv ett lösenord")]
    public String Password { get; set; }
    public String ReturUrl { get; set; }= "/";
  }
}
