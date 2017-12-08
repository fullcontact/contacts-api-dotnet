using System;
namespace FullContact.Contacts.API.Models.Fields
{
    public class Name
    {
        public String givenName { get; set; }
        public String familyName { get; set; }
        public String middleName { get; set; }
        public String prefix { get; set; }
        public String suffix { get; set; }
    }
}
