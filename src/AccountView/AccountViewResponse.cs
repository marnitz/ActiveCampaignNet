using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.AccountView
{
    public class AccountViewResponse:ApiResult
    {
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("fname")]
        public string FirstName { get; set; }
        [JsonProperty("lname")]
        public string LastName { get; set; }
        [JsonProperty("cname")]
        public string CName { get; set; }
        [JsonProperty("subscriber_limit")]
        public int SubscriberLimit { get; set; }
        [JsonProperty("trial")]
        public bool Trial { get; set; }
        [JsonProperty("credits")]
        public int Credits { get; set; }


    }
}
