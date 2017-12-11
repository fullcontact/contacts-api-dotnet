using System;
using RichardSzalay.MockHttp;

namespace FullContact.Contacts.API.Tests
{
    public class MockAPI<T>
    {
        public T Instance { get; set; }
        public MockedRequest Request { get; set; }
        public MockHttpMessageHandler Handler { get; set; }
    }
}
