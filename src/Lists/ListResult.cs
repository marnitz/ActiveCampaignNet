using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Lists
{
    public class ListResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subscriberid")]
        public int SubscriberId { get; set; }

        [JsonProperty("listid")]
        public int ListId { get; set; }

        [JsonProperty("formid")]
        public int FormId { get; set; }

        [JsonProperty("seriesid")]
        public int SeriesId { get; set; }

        [JsonProperty("sdate")]
        public DateTime? DateSubscribed { get; set; }

        [JsonProperty("udate")]
        public DateTime? DateUnsubscribed { get; set; }

        [JsonProperty("status")]
        public int ListStatus { get; set; }

        [JsonProperty("responder")]
        public int Responder { get; set; }

        [JsonProperty("sync")]
        public int Sync { get; set; }

        [JsonProperty("unsubreason")]
        public string UnsubscribeReason { get; set; }

        [JsonProperty("unsubcampaignid")]
        public int UnsubscribeCampaignId { get; set; }

        [JsonProperty("unsubmessageid")]
        public int UnsubscribeMessageId { get; set; }

        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty("ip4_sub")]
        public string IP4Sub { get; set; }

        [JsonProperty("sourceid")]
        public string SourceId { get; set; }

        [JsonProperty("sourceid_autosync")]
        public string SourceIdAutoSync { get; set; }

        [JsonProperty("ip4_last")]
        public string IP4Last { get; set; }

        [JsonProperty("ip4_unsub")]
        public string IP4Unsubscribe { get; set; }

        [JsonProperty("listname")]
        public string ListName { get; set; }

    }
}
