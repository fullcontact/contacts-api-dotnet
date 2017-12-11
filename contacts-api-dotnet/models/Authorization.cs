using System;
namespace FullContact.Contacts.API.Models
{
    public class Authorization
    {
        public String AccessToken { get; set; }
        public String RefreshToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public DateTime RefreshTokenExpiration { get; set; }
        public String Scope { get; set; }
    }
}
