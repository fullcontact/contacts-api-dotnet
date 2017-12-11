using System;
namespace FullContact.Contacts.API.Requests.Contacts
{
    public class ScrollContactsRequest : APIRequest
    {
        public int? Size { get; set; }
        public Boolean? IncludeDeletedContacts { get; set; }
        public String ScrollCursor { get; set; }
    }
}
