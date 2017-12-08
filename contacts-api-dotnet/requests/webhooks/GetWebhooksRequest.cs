using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class GetWebhooksRequest : APIRequest
    {
        public List<String> webhookIds { get; set; }
        public int? page { get; set; }
    }
}
