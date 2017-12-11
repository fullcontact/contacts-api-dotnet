using System;
using Xunit;
using FullContact.Contacts.API;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Responses;
using RichardSzalay.MockHttp;

namespace FullContact.Contacts.API.Tests
{
    public class AccountTest : APITestBase
    {
        [Fact]
        public async void TestGet()
        {
            String accessToken = this.RandomString();
            MockAPI<Account> mock = this.MockFor<Account>(
                HttpMethod.Post,
                "/api/v1/account.get",
                m => m.WithContent("{}").Respond("application/json", "{}")
            );
            APIResponse<Models.Account> res = await mock.Instance.Get(accessToken);

            mock.Handler.VerifyNoOutstandingRequest();
            mock.Handler.VerifyNoOutstandingExpectation();
        }
    }
}
