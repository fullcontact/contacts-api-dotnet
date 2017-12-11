using System;
namespace FullContact.Contacts.API.Models
{
    public class Tag
    {
        public String TagId { get; set; }
        public TagData TagData { get; set; }
        public String Etag { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
