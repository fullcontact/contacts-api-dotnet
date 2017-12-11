using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Contacts
{
    public class ManageTagsRequest : APIRequest
    {
        public List<String> ContactIds { get; set; }
        public List<String> AddTagIds { get; set; }
        public List<String> RemoveTagIds { get; set; }
    }
}
