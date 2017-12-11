using System;
namespace FullContact.Contacts.API.Requests.Contacts
{
    public class DeleteContactRequest : APIRequest
    {
        public String ContactId { get; set; }
        public String Etag { get; set; }
    }
}
