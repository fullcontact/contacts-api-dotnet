using System;
using System.Collections.Generic;
using FullContact.Contacts.API.Models.Fields;

namespace FullContact.Contacts.API.Models
{
    public class ContactData
    {
        public List<Address> addresses { get; set; }
        public DateField birthday { get; set; }
        public List<DateFieldWithType> dates { get; set; }
        public List<StandardField> emails { get; set; }
        public Name name { get; set; }
        public List<StandardField> relatedPeople { get; set; }
        public List<Organization> organizations { get; set; }
        public List<StandardField> phoneNumbers { get; set; }
        public List<URLField> urls { get; set; }
        public String notes { get; set; }
        public List<StandardField> ims { get; set; }
    }
}
