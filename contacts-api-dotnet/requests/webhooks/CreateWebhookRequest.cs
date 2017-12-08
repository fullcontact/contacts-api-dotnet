using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class CreateWebhookRequest : APIRequest
    {
        public String url { get; set; }
        public List<String> triggerIds { get; set; }
    }
}
