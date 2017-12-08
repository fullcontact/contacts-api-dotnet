using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class Team
    {
        public String teamId { get; set; }
        public TeamData teamData { get; set; }
        public List<String> teamMembers { get; set; }
        public DateTime? created { get; set; }
        public DateTime? updated { get; set; }
    }
}
