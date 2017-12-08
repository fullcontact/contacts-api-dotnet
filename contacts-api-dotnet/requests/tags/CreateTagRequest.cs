using System;
using FullContact.Contacts.API.Models;

namespace FullContact.Contacts.API.Requests.Tags
{
    public class CreateTagRequest : APIRequest
    {
        public Tag tag { get; set; }
    }
}
