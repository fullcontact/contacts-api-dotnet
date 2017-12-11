using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Responses;
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

        public async Task<APIResponse<Models.Account>> Get(String accessToken) {
            return await this.RequestAsync<Models.Account>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/account.get",
                new APIRequest(),
                null
            );
        }
    }
}
