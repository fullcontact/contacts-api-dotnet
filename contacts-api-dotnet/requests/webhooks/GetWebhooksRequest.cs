using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class GetWebhooksRequest : APIRequest
    {
        public List<String> WebhookIds { get; set; }
        public int? Page { get; set; }
    }
}
