using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;
using WhatsUp.Repositories;
using System.Web.Security;

namespace WhatsUp.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository accountRepository = new DbAccountRepository();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogIn()
        {
            return View();
        }
        public ActionResult LogOff()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(LoginModel login_account)
        {
            if (ModelState.IsValid)
            {
                // Haal het account op van de ingevoerde gegevens
                Account account = accountRepository.GetAccount(login_account.Email, login_account.Wachtwoord);
                if (account != null)
                {
                    // Zet een cookie dat iemand ingelogd is
                    FormsAuthentication.SetAuthCookie(account.Email, false);
                    // Vul de sessie met het ingelogde account
                    Session["loggedin_account"] = account;
                    return RedirectToAction("Index","ChatMessage");
                }
                else
                {
                    ModelState.AddModelError("login-error", "The user name or password provided is incorrect.");
                }
            }
            return View(login_account);
        }
        [HttpPost]
        public ActionResult Register(RegisterModel ac)
        {
            if(ModelState.IsValid)
            {
                Account acc = new Account(ac.Voornaam, ac.Achternaam, ac.Email, ac.Telefoonnr, ac.Wachtwoord);
                accountRepository.CreateAccount(acc);
                return RedirectToAction("LogIn", "Account");
            }
            return View(ac);          
        }

        [Authorize]
        [HttpPost]
        [ActionName("LogOff")]
        public ActionResult LogOffPost()
        {
            // Gooi de cookie weg en log uit
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Account");
        }
    }
}