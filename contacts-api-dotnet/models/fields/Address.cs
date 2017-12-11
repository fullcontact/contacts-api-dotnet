using System;
namespace FullContact.Contacts.API.Models.Fields
{
    public class Address
    {
        public String Type { get; set; }
        public String Street { get; set; }
        public String City { get; set; }
        public String Region { get; set; }
        public String PostalCode { get; set; }
        public String Country { get; set; }
        public String ExtendedAddress { get; set; }
    }
}
