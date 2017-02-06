using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Contact
{
    public class ContactResult:ApiResult
    {
        [JsonProperty("subscriber_id")]
        public int SubscriberId { get; set; }
        [JsonProperty("sendlast_should")]
        public string SendLastShould { get; set; }
        [JsonProperty("sendlast_did")]
        public string SendLastDid { get; set; }
    }
}
