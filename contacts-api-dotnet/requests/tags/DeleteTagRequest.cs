using System;
namespace FullContact.Contacts.API.Requests.Tags
{
    public class DeleteTagRequest : APIRequest
    {
        public String TagId { get; set; }
        public String Etag { get; set; }
    }
}
