using System;
using Newtonsoft.Json;

namespace FullContact.Contacts.API.Requests
{
    public class APIRequest
    {
        public String TeamId { get; set; }

        public override String ToString() {
            return JsonConvert.SerializeObject(this);
        }
    }
}
