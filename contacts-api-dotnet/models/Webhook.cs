using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class Webhook
    {
        public String WebhookId { get; set; }
        public String Url { get; set; }
        public List<String> Triggers { get; set; }
        public DateTime? Created { get; set; }
        public String AccountId { get; set; }
    }
}
