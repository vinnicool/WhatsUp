using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Er moet een voornaam opgegeven worden.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Er moet een achternaam opgegegeven worden.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Er moet een wachtwoord opgegeven worden.")]
        public string Wachtwoord { get; set; }

        [Required]
        [Display(Name = "Bevestig wachtwoord")]
        [Compare("Wachtwoord", ErrorMessage = "Het wachtwoord en de bevestiging matchen niet.")]
        public string BevestigWachtwoord { get; set; }

        [Required(ErrorMessage = "Er moet een telefoonnummer opgegeven worden.")]
        [Display(Name = "Telefoonnummer")]
        public string Telefoonnr { get; set; }

        [Required(ErrorMessage = "Er moet een e-mail addres opgegeven worden.")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public RegisterModel(string voornaam, string achternaam, string wachtwoord, string bevestigWachtwoord, string telefoonnr, string email)
        {
            Voornaam = voornaam;
            Achternaam = achternaam;
            Wachtwoord = wachtwoord;
            BevestigWachtwoord = bevestigWachtwoord;
            Telefoonnr = telefoonnr;
            Email = email;
        }
        public RegisterModel()
        {

        }

    }
}