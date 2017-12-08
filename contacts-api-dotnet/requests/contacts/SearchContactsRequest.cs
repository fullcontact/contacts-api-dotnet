using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Contacts
{
    public class SearchContactsRequest : APIRequest
    {
        public String searchQuery { get; set; }
        public String searchCursor { get; set; }
        public List<String> tagIds { get; set; }
    }
}
