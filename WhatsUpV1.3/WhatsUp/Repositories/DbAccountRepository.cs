using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WhatsUp.Models;

namespace WhatsUp.Repositories
{
    public class DbAccountRepository : IAccountRepository
    {
        private WhatsUpContext ctx = new WhatsUpContext();
        public Account GetAccount(string Email, string Password)
        {
            Account account = (from A in ctx.Accounts where A.Email == Email && A.Wachtwoord == Password select A).SingleOrDefault();
            return account;
        }

        public void CreateAccount(Account a)
        {
            ctx.Accounts.Add(a);
            ctx.SaveChanges();
        }
    }
}