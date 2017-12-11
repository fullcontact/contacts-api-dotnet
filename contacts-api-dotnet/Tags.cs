using System;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Requests;
using FullContact.Contacts.API.Requests.Tags;
using FullContact.Contacts.API.Responses;
using FullContact.Contacts.API.Responses.Tags;
using FullContact.Contacts.API.Models;
using System.Threading.Tasks;

namespace FullContact.Contacts.API
{
    public class Tags : API
    {
        public Tags(IDictionary<string, object> config) : base(config)
        {
        }

        public async Task<APIResponse<TagsResponseBody>> Get(String accessToken, List<String> tagIds, String teamId)
        {
            return await this.RequestAsync<TagsResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/tags.get",
                new GetTagsRequest { TagIds = tagIds, TeamId = teamId },
                null
            );
        }

        public async Task<APIResponse<TagsResponseBody>> Scroll(String accessToken, String teamId)
        {
            return await this.Scroll(accessToken, null, null, teamId, null);
        }

        public async Task<APIResponse<TagsResponseBody>> Scroll(String accessToken, String cursor, String teamId)
        {
            return await this.Scroll(accessToken, cursor, null, teamId, null);
        }

        public async Task<APIResponse<TagsResponseBody>> Scroll(String accessToken, String cursor, Boolean? includeDeleted, String teamId, int? size)
        {
            return await this.RequestAsync<TagsResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/tags.scroll",
                new ScrollTagsRequest
                {
                    TeamId = teamId,
                    ScrollCursor = cursor,
                    IncludeDeletedTags = includeDeleted,
                    Size = size
                },
                null
            );
        }

        public async Task<APIResponse<TagResponseBody>> Create(String accessToken, Tag tag, String teamId)
        {
            return await this.RequestAsync<TagResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/tags.create",
                new CreateTagRequest
                {
                    TeamId = teamId,
                    Tag = tag
                },
                null
            );
        }

        public async Task<APIResponse<TagResponseBody>> Update(String accessToken, Tag tag, String teamId)
        {
            return await this.RequestAsync<TagResponseBody>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/tags.update",
                new UpdateTagRequest
                {
                    TeamId = teamId,
                    Tag = tag
                },
                null
            );
        }

        public async Task<APIResponse<dynamic>> Delete(String accessToken, String tagId, String etag, String teamId)
        {
            return await this.RequestAsync<dynamic>(
                accessToken,
                HttpMethod.Post,
                "/api/v1/tags.delete",
                new DeleteTagRequest
                {
                    TeamId = teamId,
                    TagId = tagId,
                    Etag = etag
                },
                null
            );
        }
    }
}
