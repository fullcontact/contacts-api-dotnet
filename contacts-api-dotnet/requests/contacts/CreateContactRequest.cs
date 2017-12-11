using System;
using FullContact.Contacts.API.Models;

namespace FullContact.Contacts.API.Requests.Contacts
{
    public class CreateContactRequest : APIRequest
    {
        public Contact Contact { get; set; }
    }
}
