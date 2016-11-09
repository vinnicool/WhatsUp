using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public class PresentationViews
    {
        private WhatsUpContext ctx = new WhatsUpContext();

        public IEnumerable<LastMessage> GetMessages(int id)
        {
            List<LastMessage> lastChatMessages = new List<LastMessage>();
            IEnumerable<Contact> contacten = (from c in ctx.Contacts where c.OwnerAccount == id && c.ContactAccount != null select c).ToList();
            Account myAcc = (from a in ctx.Accounts where a.Id == id select a).SingleOrDefault();
            foreach (Contact c in contacten) //Loop alle contacten van de gebruiker langs die een account hebben
            { //account = het account van de contact
                Account account = (from a in ctx.Accounts where a.Id == c.ContactAccount select a).SingleOrDefault();
                // Haal alle laatste berrichten van de chats
                ChatMessage lastchatMessage = (from ch in ctx.ChatMessages where ch.RecieverAccountID == account.Id && ch.SenderAccountId == myAcc.Id || ch.RecieverAccountID == myAcc.Id && ch.SenderAccountId == account.Id select ch).ToList().LastOrDefault();
                if (lastchatMessage != null) //Er is ooit een berricht verstuurd
                {
                    LastMessage lcm = new LastMessage(account, lastchatMessage.Message, lastchatMessage.Datetime);
                    lastChatMessages.Add(lcm);
                }
                else // Er is nog nooit een berricht verstuud
                {
                    LastMessage lcm = new LastMessage(account, "", default(DateTime));
                    lastChatMessages.Add(lcm);
                }
            } // Lijst met( welk account in de chat zit(ex. jezlef), de teskt van het berricht, datm en tijd van ontvangen
            IEnumerable<LastMessage> lm = lastChatMessages;
            return lm;
        }
    }
}