using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class SearchWebhooksRequest : APIRequest
    {
        public String Url { get; set; }
        public int? Page { get; set; }
        public List<String> TriggerIds { get; set; }
    }
}
