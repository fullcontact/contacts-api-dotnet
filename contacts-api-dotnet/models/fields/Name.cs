using System;
namespace FullContact.Contacts.API.Models.Fields
{
    public class Name
    {
        public String GivenName { get; set; }
        public String FamilyName { get; set; }
        public String MiddleName { get; set; }
        public String Prefix { get; set; }
        public String Suffix { get; set; }
    }
}
