using System;
using System.Collections.Generic;

namespace FullContact.Contacts.API.Models
{
    public class Team
    {
        public String TeamId { get; set; }
        public TeamData TeamData { get; set; }
        public List<String> TeamMembers { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
