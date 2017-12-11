using System;
using System.Collections.Generic;
using FullContact.Contacts.API.Models;

namespace FullContact.Contacts.API.Responses.Contacts
{
    public class ContactsResponseBody
    {
        public List<Contact> Contacts { get; set; }
        public String Cursor { get; set; }
    }
}
