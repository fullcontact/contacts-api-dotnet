using System;
namespace FullContact.Contacts.API.Models
{
    public class Tag
    {
        public String tagId { get; set; }
        public TagData tagData { get; set; }
        public String etag { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
    }
}
