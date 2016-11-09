using System.Collections.Generic;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetAllContacts(int acc_id);
        Contact GetContact(int contactId);

        void DeleteContact(Contact c);
        void UpdateContact(Contact c);
        void AddContact(Contact c);
        int? GetContactAccount(string tel);
        bool ContactTelefoonExist(string tel, int accid);
    }
}