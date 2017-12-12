using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Responses;
using RichardSzalay.MockHttp;
using FullContact.Contacts.API.Responses.Teams;
using FullContact.Contacts.API.Requests;
using System.Linq;

namespace FullContact.Contacts.API.Tests
{
    public class TeamsTest : APITestBase
    {
        public TeamsTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async void TestGet()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            MockAPI<Teams> mock = this.MockFor<Teams>(
                HttpMethod.Post,
                "/api/v1/teams.get",
                m => m.WithContent("{}").Respond("application/json", "{ \"teams\": [{\"teamId\":\"" + teamId + "\"}]}")
            );
            APIResponse<TeamsResponseBody> res = await mock.Instance.Get(accessToken);
            Assert.Equal(res.Body.Teams.First().TeamId, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
        }
    }
}
