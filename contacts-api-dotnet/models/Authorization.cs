using System;
namespace FullContact.Contacts.API.Models
{
    public class Authorization
    {
        public String accessToken { get; set; }
        public String refreshToken { get; set; }
        public DateTime accessTokenExpiration { get; set; }
        public DateTime refreshTokenExpiration { get; set; }
        public String scope { get; set; }
    }
}
