using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class ContactMetadata
    {
        public String BusinessCardTranscriptionStatus { get; set; }
        public Boolean? CompanyContact { get; set; }
        public List<String> TagIds { get; set; }
    }
}
