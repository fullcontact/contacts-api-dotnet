using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Requests.Tags
{
    public class GetTagsRequest : APIRequest
    {
        public List<String> tagIds { get; set; }
    }
}
