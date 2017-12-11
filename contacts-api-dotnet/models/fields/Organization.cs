using System;
namespace FullContact.Contacts.API.Models.Fields
{
    public class Organization
    {
        public String Name { get; set; }
        public String Department { get; set; }
        public String Title { get; set; }
        public String Location { get; set; }
        public String Description { get; set; }
        public DateField StartDate { get; set; }
        public DateField EndDate { get; set; }
    }
}
