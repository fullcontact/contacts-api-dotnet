using System;
using Xunit;
using FullContact.Contacts.API;
using System.Collections.Generic;
using System.Net.Http;
using FullContact.Contacts.API.Responses;
using RichardSzalay.MockHttp;
using Xunit.Abstractions;
using FullContact.Contacts.API.Responses.Contacts;
using FullContact.Contacts.API.Requests.Contacts;

namespace FullContact.Contacts.API.Tests
{
    public class ContactsTest : APITestBase
    {
        public ContactsTest(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public async void TestGet()
        {
            String accessToken = this.RandomString();
            String contactId = this.RandomString();
            List<String> contactIds = new List<String> { contactId };
            GetContactsRequest req = new GetContactsRequest();
            req.ContactIds = contactIds;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.get",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + contactId + "\"}]}")
            );
            APIResponse<ContactsResponseBody> res = await mock.Instance.Get(accessToken, contactIds, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestGetWithTeam()
        {
            String accessToken = this.RandomString();
            String contactId = this.RandomString();
            String teamId = this.RandomString();
            List<String> contactIds = new List<String> { contactId };
            GetContactsRequest req = new GetContactsRequest();
            req.ContactIds = contactIds;
            req.TeamId = teamId;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.get",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + contactId + "\"}]}")
            );
            APIResponse<ContactsResponseBody> res = await mock.Instance.Get(accessToken, contactIds, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestScroll()
        {
            String accessToken = this.RandomString();
            ScrollContactsRequest req = new ScrollContactsRequest();
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Scroll(accessToken, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestScrollTeam()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            ScrollContactsRequest req = new ScrollContactsRequest();
            req.TeamId = teamId;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Scroll(accessToken, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestScrollWithCursor()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            String cursor = this.RandomString();
            ScrollContactsRequest req = new ScrollContactsRequest();
            req.TeamId = teamId;
            req.ScrollCursor = cursor;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Scroll(accessToken, cursor, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestScrollWithAllOptions()
        {
            String accessToken = this.RandomString();
            String teamId = this.RandomString();
            String cursor = this.RandomString();
            int size = 20;
            ScrollContactsRequest req = new ScrollContactsRequest();
            req.TeamId = teamId;
            req.ScrollCursor = cursor;
            req.Size = size;
            req.IncludeDeletedContacts = true;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.scroll",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Scroll(accessToken, cursor, true, teamId, size);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestSearch()
        {
            String accessToken = this.RandomString();
            String query = this.RandomString();
            SearchContactsRequest req = new SearchContactsRequest();
            req.SearchQuery = query;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.search",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Search(accessToken, query, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestSearchWithTeam()
        {
            String accessToken = this.RandomString();
            String query = this.RandomString();
            String teamId = this.RandomString();
            SearchContactsRequest req = new SearchContactsRequest();
            req.SearchQuery = query;
            req.TeamId = teamId;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.search",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Search(accessToken, query, teamId);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestSearchWithCursor()
        {
            String accessToken = this.RandomString();
            String query = this.RandomString();
            String cursor = this.RandomString();
            SearchContactsRequest req = new SearchContactsRequest();
            req.SearchQuery = query;
            req.SearchCursor = cursor;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.search",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contacts\": [{\"contactId\":\"" + this.RandomString() + "\"}]}")
            );

            APIResponse<ContactsResponseBody> res = await mock.Instance.Search(accessToken, query, cursor, null);
            mock.Handler.VerifyNoOutstandingExpectation();
            Assert.Equal(res.Body.Contacts.Count, 1);
        }

        [Fact]
        public async void TestCreate()
        {
            String accessToken = this.RandomString();
            Models.Contact contact = new Models.Contact();
            contact.ContactData = new Models.ContactData();
            contact.ContactData.Notes = this.RandomString();
            CreateContactRequest req = new CreateContactRequest();
            req.Contact = contact;
            MockAPI<Contacts> mock = this.MockFor<Contacts>(
                HttpMethod.Post,
                "/api/v1/contacts.create",
                m => m.WithContent(req.ToString())
                .Respond("application/json", "{ \"contact\": {\"notes\":\"Testing\"}")
            );

            APIResponse<ContactResponseBody> res = await mock.Instance.Create(accessToken, contact, null);
            mock.Handler.VerifyNoOutstandingExpectation();
        }
    }
}
