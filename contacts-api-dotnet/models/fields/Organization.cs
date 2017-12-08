using System;
namespace FullContact.Contacts.API.Models.Fields
{
    public class Organization
    {
        public String name { get; set; }
        public String department { get; set; }
        public String title { get; set; }
        public String location { get; set; }
        public String description { get; set; }
        public DateField startDate { get; set; }
        public DateField endDate { get; set; }
    }
}
