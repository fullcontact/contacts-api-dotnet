using System;
using FullContact.Contacts.API.Models;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Responses.Tags
{
    public class TagsResponseBody
    {
        public List<Tag> Tags { get; set; }
        public String Cursor { get; set; }
    }
}
