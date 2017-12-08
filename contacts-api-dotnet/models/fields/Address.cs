using System;
namespace FullContact.Contacts.API.Models.Fields
{
    public class Address
    {
        public String type { get; set; }
        public String street { get; set; }
        public String city { get; set; }
        public String region { get; set; }
        public String postalCode { get; set; }
        public String country { get; set; }
        public String extendedAddress { get; set; }
    }
}
