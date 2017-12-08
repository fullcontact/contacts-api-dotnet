using System;
namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class GetWebhookBatchesRequest : APIRequest
    {
        public String webhookId { get; set; }
        public String batchId { get; set; }
    }
}
