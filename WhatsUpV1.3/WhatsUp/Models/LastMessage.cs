using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    public class LastMessage
    {
        public Account OtherAccount { get; set; }
        public string ChatMessage { get; set; }
        public DateTime? RecievedAt { get; set; }


        public LastMessage(Account otherAccount, string chatMessage, DateTime recievedAt)
        {
            OtherAccount = otherAccount;
            ChatMessage = chatMessage;
            RecievedAt = recievedAt;
        }
        public LastMessage() { }
    }
}