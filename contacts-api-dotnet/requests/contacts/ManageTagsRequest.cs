using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Contacts
{
    public class ManageTagsRequest : APIRequest
    {
        public List<String> contactIds { get; set; }
        public List<String> addTagIds { get; set; }
        public List<String> removeTagIds { get; set; }
    }
}
