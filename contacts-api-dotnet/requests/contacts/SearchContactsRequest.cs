using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Contacts
{
    public class SearchContactsRequest : APIRequest
    {
        public String SearchQuery { get; set; }
        public String SearchCursor { get; set; }
        public List<String> TagIds { get; set; }
    }
}
