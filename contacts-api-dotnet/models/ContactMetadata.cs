using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class ContactMetadata
    {
        public String businessCardTranscriptionStatus { get; set; }
        public Boolean? companyContact { get; set; }
        public List<String> tagIds { get; set; }
    }
}
