using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public interface IAccountRepository
    {
        Account GetAccount(string Email, string Password);
        void CreateAccount(Account a);
    }
}