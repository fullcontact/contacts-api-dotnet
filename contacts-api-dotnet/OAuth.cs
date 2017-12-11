using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Models;
using System.Threading.Tasks;

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

        public async Task<APIResponse<Authorization>> ExchangeAuthCode(String code, String redirectUri) 
        {
            Dictionary<String, String> form = new Dictionary<String, String> {
                {"code", code},
                {"client_id", this._clientId},
                {"client_secret", this._clientSecret},
                {"redirect_uri", redirectUri}
            };

            return await this.RequestAsync<Authorization>(
                null,
                HttpMethod.Post,
                "/api/v1/oauth.exchangeAuthCode",
                form,
                null
            );
        }

        public async Task<APIResponse<Authorization>> RefreshAccessToken(String refreshToken)
        {
            Dictionary<String, String> form = new Dictionary<String, String> {
                {"client_id", this._clientId},
                {"client_secret", this._clientSecret},
                {"refresh_token", refreshToken}
            };

            return await this.RequestAsync<Authorization>(
                null,
                HttpMethod.Post,
                "/api/v1/oauth.refreshToken",
                form,
                null
            );
        }

        public async Task<APIResponse<dynamic>> VerifyAccessToken(String accessToken)
        {
            Dictionary<String, String> form = new Dictionary<String, String> {
                {"access_token", accessToken}
            };

            return await this.RequestAsync<dynamic>(
                null,
                HttpMethod.Post,
                "/api/v1/oauth.verifyAccessToken",
                form,
                null
            );
        }
    }
}
