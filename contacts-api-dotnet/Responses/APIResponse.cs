using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace FullContact.Contacts.API.Responses
{
    public class APIResponse<T> where T : class
    {
        public HttpStatusCode Status { get; set; }
        public HttpResponseHeaders Headers { get; set; }
        public T Body { get; set; }
    }
}
