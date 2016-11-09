using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WhatsUp.Models;
using WhatsUp.Repositories;

namespace WhatsUp.Controllers
{
    public class ChatMessageController : Controller
    {
        private IChatMessageRepository chatMessageRepository = new DbChatMessageRepository();
        private PresentationViews presview = new PresentationViews();
        // GET: ChatMessage
        [Authorize]
        public ActionResult Index()
        {
            Account acc = (Account)Session["loggedin_account"];
            IEnumerable<LastMessage> lm = presview.GetMessages(acc.Id);
            return View(lm);
        }
        [Authorize]
        public ActionResult Chat(int id) //id is de ontvanger(dus het contact)
        {
            Account acc = (Account)Session["loggedin_account"];
            IEnumerable<ChatMessage> berrichten = chatMessageRepository.GetMessages(id, acc.Id);
            // Haal de naam van het contact op waarmee je chat, zodat je deze kan laten zien bij de chat
            Contact c = chatMessageRepository.GetContact(id, acc.Id);
            ViewBag.ContactNaam = c.Voornaam + " " + c.Achternaam;
            return View(berrichten);
        }

        [HttpPost]
        public ActionResult Chat(string berricht, int id) //id is de ontvanger(het contact)
        {            
            Account acc = (Account)Session["loggedin_account"];
            ChatMessage message = new ChatMessage(berricht, DateTime.Now, acc.Id, id);
            if (ModelState.IsValid)
            {
                chatMessageRepository.AddMessage(message);
            }
            return RedirectToAction("Chat");
        }
    }
}