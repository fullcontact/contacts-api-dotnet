using System;
namespace FullContact.Contacts.API.Requests.Webhooks
{
    public class DeleteWebhookRequest : APIRequest
    {
        public String webhookId { get; set; }
    }
}
