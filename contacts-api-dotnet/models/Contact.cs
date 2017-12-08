using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class Contact
    {
        public String contactId { get; set; }
        public String teamId { get; set; }
        public List<String> sharedBy { get; set; }
        public String etag { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public ContactData contactData { get; set; }
        public ContactMetadata contactMetadata { get; set; }
    }
}
