using System;
namespace FullContact.Contacts.API.Requests.Tags
{
    public class ScrollTagsRequest : APIRequest
    {
        public int? Size { get; set; }
        public Boolean? IncludeDeletedTags { get; set; }
        public String ScrollCursor { get; set; }
    }
}
