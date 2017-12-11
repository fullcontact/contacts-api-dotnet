using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class Contact
    {
        public String ContactId { get; set; }
        public String TeamId { get; set; }
        public List<String> SharedBy { get; set; }
        public String Etag { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public ContactData ContactData { get; set; }
        public ContactMetadata ContactMetadata { get; set; }
    }
}
