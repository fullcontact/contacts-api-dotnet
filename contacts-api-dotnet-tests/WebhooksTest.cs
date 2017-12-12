using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Responses;
using RichardSzalay.MockHttp;
using FullContact.Contacts.API.Responses.Webhooks;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Requests.Webhooks;
using System.Linq;

namespace FullContact.Contacts.API.Tests
{
    public class WebhooksTest : APITestBase
    {
        public WebhooksTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async void TestGet()
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            List<String> webhookIds = new List<String> { webhookId };
            GetWebhooksRequest req = new GetWebhooksRequest();
            req.WebhookIds = webhookIds;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.get",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhooks\":[{\"webhookId\":\"" + webhookId + "\"}]}")
            );
            APIResponse<WebhooksResponseBody> res = await mock.Instance.Get(accessToken, webhookIds, null, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Webhooks.First().WebhookId, webhookId);
        }

        [Fact]
        public async void TestGetWithTeam()
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            String teamId = this.RandomString();
            List<String> webhookIds = new List<String> { webhookId };
            GetWebhooksRequest req = new GetWebhooksRequest();
            req.WebhookIds = webhookIds;
            req.TeamId = teamId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.get",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhooks\":[{\"webhookId\":\"" + webhookId + "\"}]}")
            );
            APIResponse<WebhooksResponseBody> res = await mock.Instance.Get(accessToken, webhookIds, null, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Webhooks.First().WebhookId, webhookId);
        }

        [Fact]
        public async void TestGetWithAllOptions()
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            String teamId = this.RandomString();
            int page = 10;
            List<String> webhookIds = new List<String> { webhookId };
            GetWebhooksRequest req = new GetWebhooksRequest();
            req.WebhookIds = webhookIds;
            req.TeamId = teamId;
            req.Page = page;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.get",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhooks\":[{\"webhookId\":\"" + webhookId + "\"}]}")
            );
            APIResponse<WebhooksResponseBody> res = await mock.Instance.Get(accessToken, webhookIds, page, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Webhooks.First().WebhookId, webhookId);
        }

        [Fact]
        public async void TestSearch()
        {
            String accessToken = this.RandomString();
            String url = this.RandomString();
            List<String> triggerIds = new List<String> { this.RandomString() };
            SearchWebhooksRequest req = new SearchWebhooksRequest();
            req.Url = url;
            req.TriggerIds = triggerIds;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.search",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhooks\":[{\"webhookId\":\"" + this.RandomString() + "\"}]}")
            );
            APIResponse<WebhooksResponseBody> res = await mock.Instance.Search(accessToken, url, triggerIds, null, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(1, res.Body.Webhooks.Count());
        }

        [Fact]
        public async void TestSearchWithTeam()
        {
            String accessToken = this.RandomString();
            String url = this.RandomString();
            String teamId = this.RandomString();
            List<String> triggerIds = new List<String> { this.RandomString() };
            SearchWebhooksRequest req = new SearchWebhooksRequest();
            req.Url = url;
            req.TriggerIds = triggerIds;
            req.TeamId = teamId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.search",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhooks\":[{\"webhookId\":\"" + this.RandomString() + "\"}]}")
            );
            APIResponse<WebhooksResponseBody> res = await mock.Instance.Search(accessToken, url, triggerIds, null, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(1, res.Body.Webhooks.Count());
        }

        [Fact]
        public async void TestSearchWithAllOptions()
        {
            String accessToken = this.RandomString();
            String url = this.RandomString();
            String teamId = this.RandomString();
            int page = 20;
            List<String> triggerIds = new List<String> { this.RandomString() };
            SearchWebhooksRequest req = new SearchWebhooksRequest();
            req.Url = url;
            req.TriggerIds = triggerIds;
            req.TeamId = teamId;
            req.Page = page;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.search",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhooks\":[{\"webhookId\":\"" + this.RandomString() + "\"}]}")
            );
            APIResponse<WebhooksResponseBody> res = await mock.Instance.Search(accessToken, url, triggerIds, page, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(1, res.Body.Webhooks.Count());
        }

        [Fact]
        public async void TestCreate()
        {
            String accessToken = this.RandomString();
            String url = this.RandomString();
            List<String> triggerIds = new List<String> { this.RandomString() };
            CreateWebhookRequest req = new CreateWebhookRequest();
            req.TriggerIds = triggerIds;
            req.Url = url;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.create",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhook\":{\"webhookId\":\"" + this.RandomString() + "\"}}")
            );
            APIResponse<WebhookResponseBody> res = await mock.Instance.Create(accessToken, url, triggerIds, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.NotNull(res.Body.Webhook);
        }

        [Fact]
        public async void TestCreateWithTeam()
        {
            String accessToken = this.RandomString();
            String url = this.RandomString();
            String teamId = this.RandomString();
            List<String> triggerIds = new List<String> { this.RandomString() };
            CreateWebhookRequest req = new CreateWebhookRequest();
            req.TriggerIds = triggerIds;
            req.Url = url;
            req.TeamId = teamId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.create",
                m => m.WithContent(req.ToString()).Respond("application/json", "{\"webhook\":{\"webhookId\":\"" + this.RandomString() + "\"}}")
            );
            APIResponse<WebhookResponseBody> res = await mock.Instance.Create(accessToken, url, triggerIds, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.NotNull(res.Body.Webhook);
        }

        [Fact]
        public async void TestDelete() 
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            DeleteWebhookRequest req = new DeleteWebhookRequest();
            req.WebhookId = webhookId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.delete",
                m => m.WithContent(req.ToString()).Respond("application/json", "{}")
            );
            APIResponse<dynamic> res = await mock.Instance.Delete(accessToken, webhookId, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(System.Net.HttpStatusCode.OK, res.Status);
        }

        [Fact]
        public async void TestDeleteWithTeam()
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            String teamId = this.RandomString();
            DeleteWebhookRequest req = new DeleteWebhookRequest();
            req.WebhookId = webhookId;
            req.TeamId = teamId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.delete",
                m => m.WithContent(req.ToString()).Respond("application/json", "{}")
            );
            APIResponse<dynamic> res = await mock.Instance.Delete(accessToken, webhookId, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(System.Net.HttpStatusCode.OK, res.Status);
        }

        [Fact]
        public async void TestGetBatches()
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            String batchId = this.RandomString();
            GetWebhookBatchesRequest req = new GetWebhookBatchesRequest();
            req.WebhookId = webhookId;
            req.BatchId = batchId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.getBatches",
                m => m.WithContent(req.ToString()).Respond("application/json", "{}")
            );
            APIResponse<dynamic> res = await mock.Instance.GetBatches(accessToken, webhookId, batchId, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(System.Net.HttpStatusCode.OK, res.Status);
        }

        [Fact]
        public async void TestGetBatchesWithTeam()
        {
            String accessToken = this.RandomString();
            String webhookId = this.RandomString();
            String batchId = this.RandomString();
            String teamId = this.RandomString();
            GetWebhookBatchesRequest req = new GetWebhookBatchesRequest();
            req.WebhookId = webhookId;
            req.BatchId = batchId;
            req.TeamId = teamId;
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.getBatches",
                m => m.WithContent(req.ToString()).Respond("application/json", "{}")
            );
            APIResponse<dynamic> res = await mock.Instance.GetBatches(accessToken, webhookId, batchId, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(System.Net.HttpStatusCode.OK, res.Status);
        }

        [Fact]
        public async void TestGetTriggers()
        {
            String accessToken = this.RandomString();
            String trigger = this.RandomString();
            MockAPI<Webhooks> mock = this.MockFor<Webhooks>(
                HttpMethod.Post,
                "/api/v1/webhooks.getTriggers",
                m => m.WithContent("{}").Respond("application/json", "{ \"triggers\": [\""+trigger+"\"]}")
            );
            APIResponse<TriggersResponseBody> res = await mock.Instance.GetTriggers(accessToken);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(trigger, res.Body.Triggers.First());
        }
    }
}
