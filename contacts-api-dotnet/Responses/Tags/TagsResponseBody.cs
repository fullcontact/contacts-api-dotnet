using System;
using FullContact.Contacts.API.Models;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Responses.Tags
{
    public class TagsResponseBody
    {
        public List<Tag> tags { get; set; }
        public String cursor { get; set; }
    }
}
