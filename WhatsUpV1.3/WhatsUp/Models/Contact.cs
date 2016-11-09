using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WhatsUp.Models
{
    [Table("Contacts")]
    public class Contact
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Er moet een voornaam opgegeven worden.")]
        public string Voornaam { get; set; }

        [Required(ErrorMessage = "Er moet een achternaam opgegeven worden.")]
        public string Achternaam { get; set; }

        [Required(ErrorMessage = "Er moet een E-mail adres opgegeven worden.")]
        [Display(Name = "E-mail adres")]
        public string Email { get; set;}

        [Required(ErrorMessage = "Er moet een telefoon nummer opgegeven worden.")]
        [Display(Name = "Telefoon nummer")]
        public string Telefoonnr { get; set; }

        public int OwnerAccount { get; set; }
        public int? ContactAccount { get; set; }
        public Contact()
        {

        }
        public Contact(string voornaam, string achternaam , string email, string telefoonnr, int owneraccount, int? contactaccount)
        {
            //Id = id;
            Voornaam = voornaam;
            Achternaam = achternaam;
            Email = email;
            Telefoonnr = telefoonnr;
            owneraccount = OwnerAccount;
            ContactAccount = contactaccount;
        }
    }
}