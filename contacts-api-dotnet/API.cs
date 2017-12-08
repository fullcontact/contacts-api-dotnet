using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace FullContact.Contacts.API
{
    public abstract class API
    {
        readonly IDictionary<String, Object> _config;
        protected readonly String _baseUrl;
        protected readonly String _clientId;
        protected readonly String _clientSecret;

        public API(IDictionary<String, Object> config) {
            this._config = config;
            this._baseUrl = (String)config["apiUrl"];
            this._clientId = (String)config["clientId"];
            this._clientSecret = (String)config["clientSecret"];
        }


    }
}
