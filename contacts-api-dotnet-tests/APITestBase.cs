using System;
using FullContact.Contacts.API;
using System.Collections.Generic;
using RichardSzalay.MockHttp;
using System.Net.Http;
using Xunit.Abstractions;

namespace FullContact.Contacts.API.Tests
{
    public class APITestBase
    {
        protected readonly ITestOutputHelper output;

        public APITestBase(ITestOutputHelper output)
        {
            this.output = output;
        }

        protected readonly String baseUrl = "https://app.fullcontact.com";
        protected readonly String clientId = Guid.NewGuid().ToString();
        protected readonly String clientSecret = Guid.NewGuid().ToString();

        protected String RandomString() {
            return Guid.NewGuid().ToString();
        }

        protected MockAPI<T> MockFor<T>(HttpMethod method, String uri) where T : API
        {
            return this.MockFor<T>(method, uri, null);
        }

        protected MockAPI<T> MockFor<T>(HttpMethod method, String uri, Func<MockedRequest, MockedRequest> action) where T : API
        {
            MockHttpMessageHandler mockHandler = new MockHttpMessageHandler();
            Dictionary<String, Object> config = new Dictionary<String, Object>();
            config.Add("apiUrl", this.baseUrl);
            config.Add("clientId", this.clientId);
            config.Add("clientSecret", this.clientSecret);
            this.output.WriteLine(String.Format("{0}{1}", this.baseUrl, uri));
            MockedRequest req = mockHandler.Expect(method, String.Format("{0}{1}", this.baseUrl, uri));

            if(action != null) {
                req = action.Invoke(req);
            }

            MockAPI<T> mock = new MockAPI<T>();
            mock.Request = req;
            mock.Instance = (T) Activator.CreateInstance(typeof(T), new object[] { config, mockHandler.ToHttpClient() });
            mock.Handler = mockHandler;
            return mock;
        }
    }
}
