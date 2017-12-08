using System;
namespace FullContact.Contacts.API.Requests.Contacts
{
    public class DeleteContactRequest : APIRequest
    {
        public String contactId { get; set; }
        public String etag { get; set; }
    }
}
