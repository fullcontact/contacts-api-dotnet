using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class Webhook
    {
        public String webhookId { get; set; }
        public String url { get; set; }
        public List<String> triggers { get; set; }
        public DateTime? created { get; set; }
        public String accountId { get; set; }
    }
}
