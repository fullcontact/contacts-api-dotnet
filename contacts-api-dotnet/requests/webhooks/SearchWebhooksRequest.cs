using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class SearchWebhooksRequest : APIRequest
    {
        public String url { get; set; }
        public int? page { get; set; }
        public List<String> triggerIds { get; set; }
    }
}
