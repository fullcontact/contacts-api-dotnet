using System;
namespace FullContact.Contacts.API.Requests.Tags
{
    public class DeleteTagRequest : APIRequest
    {
        public String tagId { get; set; }
        public String etag { get; set; }
    }
}
