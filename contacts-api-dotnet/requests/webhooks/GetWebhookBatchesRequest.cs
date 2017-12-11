using System;
namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class GetWebhookBatchesRequest : APIRequest
    {
        public String WebhookId { get; set; }
        public String BatchId { get; set; }
    }
}
