using System;
using System.Collections.Generic;
namespace FullContact.Contacts.API.Responses
{
    public class APIResponse<T> where T : class
    {
        public int status { get; set; }
        public IDictionary<String, String> headers { get; set; }
        public T body { get; set; }
    }
}
