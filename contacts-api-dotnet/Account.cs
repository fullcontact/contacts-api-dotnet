using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Responses.Account;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public class Account : API
    {
        public Account(IDictionary<string, object> config) : base(config)
        {
        }

        public Account(IDictionary<string, object> config, HttpClient client) : base(config, client)
        {
        }

        /// <summary>
        /// Gets the Account and Profile information for the current user.
        /// </summary>
        /// <returns>The account</returns>
        /// <param name="accessToken">Access token.</param>
        public async Task<APIResponse<AccountResponseBody>> Get(String accessToken) {
            return await this.RequestAsync<AccountResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/account.get",
                new APIRequest(),
                null
            );
        }
    }
}
