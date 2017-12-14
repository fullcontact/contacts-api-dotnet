using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Models;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Requests.Webhooks;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Responses.Webhooks;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public class Webhooks : API
    {
        public Webhooks(IDictionary<string, object> config) : base(config)
        {
        }

        public Webhooks(IDictionary<string, object> config, HttpClient client) : base(config, client)
        {
        }

        /// <summary>
        /// Gets a list of webhooks by their ids.
        /// </summary>
        /// <returns>The list of webhooks.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="webhookIds">Webhook identifiers.</param>
        /// <param name="page">Page.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<WebhooksResponseBody>> Get(String accessToken, List<String> webhookIds, int? page, String teamId)
        {
            return await this.RequestAsync<WebhooksResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/webhooks.get",
                new GetWebhooksRequest { WebhookIds = webhookIds, Page = page, TeamId = teamId },
                null
            );
        }

        /// <summary>
        /// Searches the list of webhooks.
        /// </summary>
        /// <returns>The list of matching webhooks.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="url">URL.</param>
        /// <param name="triggerIds">Trigger identifiers.</param>
        /// <param name="page">Page.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<WebhooksResponseBody>> Search(String accessToken, String url, List<String> triggerIds, int? page, String teamId)
        {
            return await this.RequestAsync<WebhooksResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/webhooks.search",
                new SearchWebhooksRequest { Url = url, TriggerIds = triggerIds, Page = page, TeamId = teamId },
                null
            );
        }

        /// <summary>
        /// Creates a new webhook.
        /// </summary>
        /// <returns>The created webhook.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="url">URL.</param>
        /// <param name="triggerIds">Trigger identifiers.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<WebhookResponseBody>> Create(String accessToken, String url, List<String> triggerIds, String teamId)
        {
            return await this.RequestAsync<WebhookResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/webhooks.create",
                new CreateWebhookRequest { Url = url, TriggerIds = triggerIds, TeamId = teamId },
                null
            );
        }

        /// <summary>
        /// Deletes an existing webhook.
        /// </summary>
        /// <returns></returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="webhookId">Webhook identifier.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<dynamic>> Delete(String accessToken, String webhookId, String teamId)
        {
            return await this.RequestAsync<dynamic>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/webhooks.delete",
                new DeleteWebhookRequest { WebhookId = webhookId, TeamId = teamId },
                null
            );
        }

        /// <summary>
        /// Gets a list of batches for a webhook id and batch id.
        /// </summary>
        /// <returns>The batches.</returns>
        /// <param name="accessToken">Access token.</param>
        /// <param name="webhookId">Webhook identifier.</param>
        /// <param name="batchId">Batch identifier.</param>
        /// <param name="teamId">Team identifier.</param>
        public async Task<APIResponse<dynamic>> GetBatches(String accessToken, String webhookId, String batchId, String teamId)
        {
            return await this.RequestAsync<dynamic>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/webhooks.getBatches",
                new GetWebhookBatchesRequest { WebhookId = webhookId, BatchId = batchId, TeamId = teamId },
                null
            );
        }

        /// <summary>
        /// Gets a list of available triggers for creating a new webhook.
        /// </summary>
        /// <returns>The list of triggers.</returns>
        /// <param name="accessToken">Access token.</param>
        public async Task<APIResponse<TriggersResponseBody>> GetTriggers(String accessToken)
        {
            return await this.RequestAsync<TriggersResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/webhooks.getTriggers",
                new APIRequest(),
                null
            );
        }
    }
}
