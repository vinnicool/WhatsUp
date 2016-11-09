using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;
using WhatsUp.Repositories;

namespace WhatsUp.Controllers
{
    public class ContactController : Controller
    {
        private IContactRepository contactRepository = new DbContactRepository();
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            Account acc = (Account)Session["loggedin_account"];
            // Haal contacten op
            IEnumerable<Contact> contacts = contactRepository.GetAllContacts(acc.Id);
            return View(contacts);
        }
        [Authorize]
        public ActionResult Add()
        {
            return View();
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            // haal coctact uit db met id <id>
            Contact c = contactRepository.GetContact(id);
            return View(c);
        }
        [Authorize]
        public ActionResult Delete(int id)
        {
            // haal contact op uit database
            Contact c = contactRepository.GetContact(id);
            return View(c);
        }

        [HttpPost]
        public ActionResult Delete(Contact c)
        {
            if (ModelState.IsValid)
            {
                contactRepository.DeleteContact(c);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete");
        }

        [HttpPost]
        public ActionResult Add(Contact contact)
        {
            Account acc = (Account)Session["loggedin_account"];
            contact.OwnerAccount = acc.Id;
            contact.ContactAccount = contactRepository.GetContactAccount(contact.Telefoonnr);
            if (ModelState.IsValid)
            {
                if (!contactRepository.ContactTelefoonExist(contact.Telefoonnr, acc.Id))
                {
                    contactRepository.AddContact(contact);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("telInGebruik", "Het ingevoerde telefoonnummer staat al in uw contacten.");
                    return View(); // RedirectToAction("Add");
                }
            }
            return RedirectToAction("Add");
        }
        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            Account acc = (Account)Session["loggedin_account"];
            if (ModelState.IsValid)
            {
                //Contact c = new Contact(contact.Id, contact.Voornaam, contact.Achternaam, contact.Email, contact.Telefoonnr, acc.Id, null);
                contact.OwnerAccount = acc.Id;
                contact.ContactAccount = contactRepository.GetContactAccount(contact.Telefoonnr);
                contactRepository.UpdateContact(contact);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Edit");
        }


    }
}