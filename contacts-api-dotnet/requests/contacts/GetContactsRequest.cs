using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Contacts
{
    public class GetContactsRequest : APIRequest
    {
        public List<String> ContactIds { get; set; }
    }
}
