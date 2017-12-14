using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Responses.Teams;
using FullContact.Contacts.API.Models;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public class Teams : API
    {
        public Teams(IDictionary<string, object> config) : base(config)
        {
        }

        public Teams(IDictionary<string, object> config, HttpClient client) : base(config, client)
        {
        }

        /// <summary>
        /// Gets a list of teams that the user belongs to.
        /// </summary>
        /// <returns>The list of teams.</returns>
        /// <param name="accessToken">Access token.</param>
        public async Task<APIResponse<TeamsResponseBody>> Get(String accessToken)
        {
            return await this.RequestAsync<TeamsResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/teams.get",
                new APIRequest(),
                null
            );
        }
    }
}
