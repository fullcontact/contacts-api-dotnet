using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FullContact.Contacts.API
{
    public static class Config
    {
        public static readonly JsonSerializerSettings JsonSerializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
    }
}
