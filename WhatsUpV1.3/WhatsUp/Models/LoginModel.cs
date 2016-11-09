using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class LoginModel
    {
        [Required]
        [Display(Name = "Email adres")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Wachtwoord")]
        [DataType(DataType.Password)]
        public string Wachtwoord { get; set; }

        public LoginModel(string email, string wachtwoord)
        {
            Email = email;
            Wachtwoord = wachtwoord;
        }
        public LoginModel()
        {
            //Lege constructor
        }
    }
}