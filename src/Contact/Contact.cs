using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Contact
{
    public class Contact
    {
        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OrganizationName { get; set; }
        public string[] Tags { get; set; }
        public string IPv4 { get; set; }
        public Dictionary<int, string> CustomFields { get; set; }
        public Dictionary<string, string> PersonilizationTags { get; set; }
        public int[] Lists { get; set; }
        public Dictionary<int, Fields.Enums.ActiveUnsubscribed> ListStatus { get; set; }
        public int? Form { get; set; }
        public Dictionary<int, bool> NoResponders { get; set; }
        public Dictionary<int,DateTime> ListSubscribedDate { get; set; }
        public Dictionary<int, bool> InstantResponders { get; set; }
        public Dictionary<int, bool> LastMessage { get; set; }
    }
}
