using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public class DbChatMessageRepository : IChatMessageRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();
        //Redundant
        public IEnumerable<Contact> GetContacts(int Id)
        {
            var contacten = (from c in ctx.Contacts where c.OwnerAccount == Id && c.ContactAccount != null select c).ToList();
            return contacten;
        }
        //Redundant
        public int? GetRecieverAccount(int id)
        {
            Contact con = ctx.Contacts.SingleOrDefault(c => c.Id == id);
            return con.ContactAccount;       
        }
        //Voegt het berricht toe in de database
        public void AddMessage(ChatMessage message)
        {
            ctx.ChatMessages.Add(message);
            ctx.SaveChanges();
        }
        //Haalt alle berrichten op
        public IEnumerable<ChatMessage> GetMessages(int reciever, int sender)
        {
            var berichten = (from ch in ctx.ChatMessages where ch.RecieverAccountID == reciever && ch.SenderAccountId == sender || ch.RecieverAccountID == sender && ch.SenderAccountId == reciever select ch).ToList();
            return berichten;
        }
        //Haal een enkel contact op
        public Contact GetContact(int contactAccount, int acc_id)
        {
            Contact contact = (from c in ctx.Contacts where c.ContactAccount == contactAccount && c.OwnerAccount == acc_id select c).SingleOrDefault();
            //Contact con = contact.SingleOrDefault();
            return contact;
        }      
    }
}