using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WhatsUp.Models
{
    [Table("ChatMessages")]
    public class ChatMessage
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Er moet een berricht opgegeven worden.")]
        public string Message { get; set; }
        public DateTime Datetime { get; set; }
        public int SenderAccountId { get; set; }
        public int RecieverAccountID { get; set; }

        public ChatMessage(string message, DateTime datetime, int senderaccountid, int recieveraccountid)
        {
            //Id = id;
            Message = message;
            Datetime = datetime;
            SenderAccountId = senderaccountid;
            RecieverAccountID = recieveraccountid;
        }
        // Lege constructor
        public ChatMessage()
        {
        }
    }
}