using System;
namespace FullContact.Contacts.API.Requests.Contacts
{
    public class ScrollContactsRequest : APIRequest
    {
        public int? size { get; set; }
        public Boolean? includeDeletedContacts { get; set; }
        public String scrollCursor { get; set; }
    }
}
