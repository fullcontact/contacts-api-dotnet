using System;
namespace FullContact.Contacts.API.Models
{
    public class Account
    {
        public String AccountId { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public ContactData ProfileData { get; set; }
    }
}
