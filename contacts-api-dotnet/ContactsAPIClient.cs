using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API
{
    public class ContactsAPIClient
    {
        private Dictionary<String, Object> config;
        private Contacts _contacts;
        private OAuth _oauth;
        private Tags _tags;
        private Teams _teams;
        private Webhooks _webhooks;
        private Account _account;

        public ContactsAPIClient(String clientId, String clientSecret) : this(clientId, clientSecret, null)
        {
            
        }

        public ContactsAPIClient(String clientId, String clientSecret, Dictionary<String, Object> config) 
        {
            this.config = config == null ? new Dictionary<string, object>() : config;

            this.config.Add("clientId", clientId);
            this.config.Add("clientSecret", clientSecret);

            if (!this.config.ContainsKey("apiUrl"))
            {
                this.config.Add("apiUrl", "https://app.fullcontact.com");
            }

            if (!this.config.ContainsKey("userAgent"))
            {
                this.config.Add("userAgent", "contacts-api-dotnet");
            }

            this._contacts = new Contacts(this.config);
            this._oauth = new OAuth(this.config);
            this._tags = new Tags(this.config);
            this._teams = new Teams(this.config);
            this._webhooks = new Webhooks(this.config);
            this._account = new Account(this.config);
        }

        public Contacts Contacts 
        {
            get 
            {
                return this._contacts;
            }
        }

        public OAuth OAuth
        {
            get
            {
                return this._oauth;
            }
        }

        public Tags Tags
        {
            get
            {
                return this._tags;
            }
        }

        public Teams Teams
        {
            get
            {
                return this._teams;
            }
        }

        public Webhooks Webhooks
        {
            get
            {
                return this._webhooks;
            }
        }

        public Account Account
        {
            get
            {
                return this._account;
            }
        }
    }
}
