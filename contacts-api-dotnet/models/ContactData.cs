using System;
using System.Collections.Generic;
using FullContact.Contacts.API.Models.Fields;

namespace FullContact.Contacts.API.Models
{
    public class ContactData
    {
        public List<Address> Addresses { get; set; }
        public DateField Birthday { get; set; }
        public List<DateFieldWithType> Dates { get; set; }
        public List<StandardField> Emails { get; set; }
        public Name Name { get; set; }
        public List<StandardField> RelatedPeople { get; set; }
        public List<Organization> Organizations { get; set; }
        public List<StandardField> PhoneNumbers { get; set; }
        public List<URLField> Urls { get; set; }
        public String Notes { get; set; }
        public List<StandardField> Ims { get; set; }
    }
}
