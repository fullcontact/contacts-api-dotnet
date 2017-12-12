using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Responses;
using RichardSzalay.MockHttp;
using FullContact.Contacts.API.Responses.Tags;
using FullContact.Contacts.API.Requests.Tags;

namespace FullContact.Contacts.API.Tests
{
    public class TagsTest : APITestBase
    {
        public TagsTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async void TestGet()
        {
            String accessToken = this.RandomString();
            String tagId = this.RandomString();
            List<String> tagIds = new List<String> { tagId };
            GetTagsRequest req = new GetTagsRequest();
            req.TagIds = tagIds;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.get",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"tags\": [{\"tagId\":\"" + tagId + "\"}]}")
            );
            APIResponse<TagsResponseBody> res = await mock.Instance.Get(accessToken, tagIds, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Tags.Count, 1);
        }

        [Fact]
        public async void TestGetWithTeam()
        {
            String accessToken = this.RandomString();
            String tagId = this.RandomString();
            String teamId = this.RandomString();
            List<String> tagIds = new List<String> { tagId };
            GetTagsRequest req = new GetTagsRequest();
            req.TagIds = tagIds;
            req.TeamId = teamId;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.get",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"tags\": [{\"tagId\":\"" + tagId + "\"}]}")
            );
            APIResponse<TagsResponseBody> res = await mock.Instance.Get(accessToken, tagIds, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Tags.Count, 1);
        }

        [Fact]
        public async void TestScroll()
        {
            String accessToken = this.RandomString();
            ScrollTagsRequest req = new ScrollTagsRequest();
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"tags\": [{\"tagId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<TagsResponseBody> res = await mock.Instance.Scroll(accessToken, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Tags.Count, 1);
        }

        [Fact]
        public async void TestScrollTeam()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            ScrollTagsRequest req = new ScrollTagsRequest();
            req.TeamId = teamId;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"tags\": [{\"tagId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<TagsResponseBody> res = await mock.Instance.Scroll(accessToken, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Tags.Count, 1);
        }

        [Fact]
        public async void TestScrollWithCursor()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            String cursor = this.RandomString();
            ScrollTagsRequest req = new ScrollTagsRequest();
            req.TeamId = teamId;
            req.ScrollCursor = cursor;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"tags\": [{\"tagId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<TagsResponseBody> res = await mock.Instance.Scroll(accessToken, cursor, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Tags.Count, 1);
        }

        [Fact]
        public async void TestScrollWithAllOptions()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            String cursor = this.RandomString();
            int size = 20;
            ScrollTagsRequest req = new ScrollTagsRequest();
            req.TeamId = teamId;
            req.ScrollCursor = cursor;
            req.Size = size;
            req.IncludeDeletedTags = true;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"tags\": [{\"tagId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<TagsResponseBody> res = await mock.Instance.Scroll(accessToken, cursor, true, teamId, size);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Tags.Count, 1);
        }

        [Fact]
        public async void TestCreate()
        {
            String accessToken = this.RandomString();
            Models.Tag tag= new Models.Tag();
            tag.TagData = new Models.TagData();
            tag.TagData.Name = this.RandomString();
            CreateTagRequest req = new CreateTagRequest();
            req.Tag = tag;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.create",
                m => m.WithContent(req.ToString())
                .Respond("application/json", req.ToString())
            );

            APIResponse<TagResponseBody> res = await mock.Instance.Create(accessToken, tag, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(tag.TagData.Name, res.Body.Tag.TagData.Name);
        }

        [Fact]
        public async void TestCreateWithTeam()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            Models.Tag tag = new Models.Tag();
            tag.TagData = new Models.TagData();
            tag.TagData.Name = this.RandomString();
            CreateTagRequest req = new CreateTagRequest();
            req.Tag = tag;
            req.TeamId = teamId;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.create",
                m => m.WithContent(req.ToString())
                .Respond("application/json", req.ToString())
            );

            APIResponse<TagResponseBody> res = await mock.Instance.Create(accessToken, tag, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(tag.TagData.Name, res.Body.Tag.TagData.Name);        
        }

        [Fact]
        public async void TestUpdate()
        {
            String accessToken = this.RandomString();
            Models.Tag tag = new Models.Tag();
            tag.TagId = this.RandomString();
            tag.TagData = new Models.TagData();
            tag.TagData.Name = this.RandomString();
            UpdateTagRequest req = new UpdateTagRequest();
            req.Tag = tag;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.update",
                m => m.WithContent(req.ToString())
                .Respond("application/json", req.ToString())
            );

            APIResponse<TagResponseBody> res = await mock.Instance.Update(accessToken, tag, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(tag.TagId, res.Body.Tag.TagId);
        }

        [Fact]
        public async void TestUpdateWithTeam()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            Models.Tag tag = new Models.Tag();
            tag.TagId = this.RandomString();
            tag.TagData = new Models.TagData();
            tag.TagData.Name = this.RandomString();
            UpdateTagRequest req = new UpdateTagRequest();
            req.Tag = tag;
            req.TeamId = teamId;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.update",
                m => m.WithContent(req.ToString())
                .Respond("application/json", req.ToString())
            );

            APIResponse<TagResponseBody> res = await mock.Instance.Update(accessToken, tag, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(tag.TagId, res.Body.Tag.TagId);
        }

        [Fact]
        public async void TestDelete()
        {
            String accessToken = this.RandomString();
            String etag = this.RandomString();
            String tagId = this.RandomString();
            DeleteTagRequest req = new DeleteTagRequest();
            req.TagId = tagId;
            req.Etag = etag;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.delete",
                m => m.WithContent(req.ToString())
                .Respond("application/json", req.ToString())
            );

            APIResponse<dynamic> res = await mock.Instance.Delete(accessToken, tagId, etag, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(System.Net.HttpStatusCode.OK, res.Status);
        }

        [Fact]
        public async void TestDeleteWithTeam()
        {
            String accessToken = this.RandomString();
            String etag = this.RandomString();
            String tagId = this.RandomString();
            String teamId = this.RandomString();
            DeleteTagRequest req = new DeleteTagRequest();
            req.TagId = tagId;
            req.Etag = etag;
            req.TeamId = teamId;
            MockAPI<Tags> mock = this.MockFor<Tags>(
                HttpMethod.Post,
                "/api/v1/tags.delete",
                m => m.WithContent(req.ToString())
                .Respond("application/json", req.ToString())
            );

            APIResponse<dynamic> res = await mock.Instance.Delete(accessToken, tagId, etag, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(System.Net.HttpStatusCode.OK, res.Status);
        }
    }
}
