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

        public OAuth(IDictionary<string, object> config, HttpClient client) : base(config, client)
        {
        }

        /// <summary>
        /// Returns the URL to redirect a user to for the Authorization step of the OAuth process.
        /// </summary>
        /// <returns>The authorization URL.</returns>
        /// <param name="scopes">Scopes.</param>
        /// <param name="redirectUri">Redirect URI.</param>
        /// <param name="state">State.</param>
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

        /// <summary>
        /// "Exchanges the code returned from a the authorization redirect for access token and refresh token.
        /// </summary>
        /// <returns>Authorization</returns>
        /// <param name="code">Code.</param>
        /// <param name="redirectUri">Redirect URI.</param>
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

        /// <summary>
        /// Obtains a new access token from a refresh token.
        /// </summary>
        /// <returns>The access token.</returns>
        /// <param name="refreshToken">Refresh token.</param>
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

        /// <summary>
        /// "Checks if an access token is still valid"
        /// </summary>
        /// <returns></returns>
        /// <param name="accessToken">Access token.</param>
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
