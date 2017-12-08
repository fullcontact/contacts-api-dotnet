using System;
namespace FullContact.Contacts.API.Requests.Tags
{
    public class ScrollTagsRequest : APIRequest
    {
        public int? size { get; set; }
        public Boolean? includeDeletedTags { get; set; }
        public String scrollCursor { get; set; }
    }
}
