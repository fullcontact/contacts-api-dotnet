using System;
using FullContact.Contacts.API.Requests;
using Xunit;

namespace FullContact.Contacts.API.Tests
{
    public class APIRequestTest
    {
        [Fact]
        public void TestToString()
        {
            APIRequest req = new APIRequest();
            Assert.Equal(req.ToString(), "{}");
        }

        [Fact]
        public void TestToStringWithTeamId()
        {
            String teamId = Guid.NewGuid().ToString();
            APIRequest req = new APIRequest();
            req.TeamId = teamId;
            String expected = String.Format("{{\"teamId\":\"{0}\"}}", teamId);
            Assert.Equal(expected, req.ToString());
        }
    }
}
