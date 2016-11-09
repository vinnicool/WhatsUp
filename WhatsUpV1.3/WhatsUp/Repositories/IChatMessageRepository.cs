using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;
namespace WhatsUp.Repositories
{
    public interface IChatMessageRepository
    {
        IEnumerable<Contact> GetContacts(int Id);
        int? GetRecieverAccount(int id);
        void AddMessage(ChatMessage message);
        IEnumerable<ChatMessage> GetMessages(int reciever, int sender);
        Contact GetContact(int id, int id2);
    }
}