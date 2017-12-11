using System;
using System.Collections.Generic;
using FullContact.Contacts.API.Models;

namespace FullContact.Contacts.API.Responses.Webhooks
{
    public class WebhooksResponseBody
    {
        public List<Webhook> Webhooks { get; set; }        
    }
}
