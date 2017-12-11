using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class CreateWebhookRequest : APIRequest
    {
        public String Url { get; set; }
        public List<String> TriggerIds { get; set; }
    }
}
