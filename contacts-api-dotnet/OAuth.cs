using System;
using System.Collections.Generic;
using System.Net.Http;

namespace FullContact.Contacts.API
{
    public class OAuth : API
    {
        public OAuth(IDictionary<string, object> config) : base(config)
        {
        }

        public String getAuthorizationUrl(List<String> scopes, String redirectUri, String state) {
            return String.Format(
                "{0}/oauth/authorize?client_id={1}&scopes={2}&redirect_uri={3}&state={4}",
                this._baseUrl,
                Uri.EscapeUriString(this._clientId),
                Uri.EscapeUriString(String.Join(",", scopes)),
                Uri.EscapeUriString(redirectUri),
                Uri.EscapeUriString(state)
            );
        }

    }
}
