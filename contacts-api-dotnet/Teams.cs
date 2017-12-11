using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Models;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public class Teams : API
    {
        public Teams(IDictionary<string, object> config) : base(config)
        {
        }

        public async Task<APIResponse<Team>> Get(String accessToken)
        {
            return await this.RequestAsync<Team>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/teams.get",
                new APIRequest(),
                null
            );
        }
    }
}
