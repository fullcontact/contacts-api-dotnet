using System;
namespace FullContact.Contacts.API.Models
{
    public class Account
    {
        public String accountId { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
        public ContactData profileData { get; set; }
    }
}
