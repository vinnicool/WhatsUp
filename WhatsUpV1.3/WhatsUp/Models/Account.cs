using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUp.Models
{
    [Table("Accounts")]
    public class Account
    {
        
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public string Telefoonnr { get; set; }
        public string Wachtwoord { get; set; }

        public Account()
        {

        }
        public Account(string voornaam, string achternaam, string email, string telefoonnr, string wachtwoord)
        {
            //Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Telefoonnr = telefoonnr;
            Wachtwoord = wachtwoord;
        }
    }
}