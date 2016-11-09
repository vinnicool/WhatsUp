using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;
using System.Data.Entity;

namespace WhatsUp.Repositories
{
    public class DbContactRepository : IContactRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public IEnumerable<Contact> GetAllContacts(int acc_id)
        {
            var contacten = (from A in ctx.Contacts where A.OwnerAccount == acc_id select A).ToList();                    
            return contacten;
        }
        public Contact GetContact(int ContactId)
        {      
            return ctx.Contacts.SingleOrDefault(c => c.Id == ContactId);
        }
        public void DeleteContact(Contact contact)
        {
            Contact contactToDelete = ctx.Contacts.SingleOrDefault(c => c.Id == contact.Id);
            if (contactToDelete != null)
            {
                ctx.Contacts.Remove(contactToDelete);
                ctx.SaveChanges();
            }
        }
        public void UpdateContact(Contact contact)
        {
            Contact dbContact = ctx.Contacts.SingleOrDefault(c => c.Id == contact.Id);
            if (dbContact != null)
            {
                dbContact.Voornaam = contact.Voornaam;
                dbContact.Achternaam = contact.Achternaam;
                dbContact.Email = contact.Email;
                dbContact.Telefoonnr = contact.Telefoonnr;
                ctx.SaveChanges();
            }
        }
        public void AddContact(Contact c)
        {
            ctx.Contacts.Add(c);
            ctx.SaveChanges();
        }

        public int? GetContactAccount(string tel)
        {
            Account a = ctx.Accounts.SingleOrDefault(c => c.Telefoonnr == tel);
            if(a != null)
            {
                return a.Id;
            }
            return null;
        }

        public bool ContactTelefoonExist(string tel, int accid)
        {
            Contact contact = (from c in ctx.Contacts where c.Telefoonnr == tel && c.OwnerAccount == accid select c).SingleOrDefault();
            return (contact != null);
        }
    }
}