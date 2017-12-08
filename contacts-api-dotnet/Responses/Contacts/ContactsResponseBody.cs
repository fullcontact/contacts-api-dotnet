using System;
using System.Collections.Generic;
using FullContact.Contacts.API.Models;

namespace FullContact.Contacts.API.Responses.Contacts
{
    public class ContactsResponseBody
    {
        public List<Contact> contacts { get; set; }
        public String cursor { get; set; }
    }
}
