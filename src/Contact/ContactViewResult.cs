using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Contact
{
    public class ContactViewResult:ApiResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("subscriberid")]
        public int SubscriberId { get; set; }

        [JsonProperty("listid")]
        public int ListId { get; set; }

        [JsonProperty("formid")]
        public int FormId { get; set; }

        [JsonProperty("sdate")]
        public DateTime DateSubscribed { get; set; }

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

        [JsonProperty("orgid")]
        public int OrganizationId { get; set; }

        [JsonProperty("orgname")]
        public string OrganizationName { get; set; }

        [JsonProperty("cdate")]
        public DateTime? DateCSubscribed { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("bounced_hard")]
        public int HardBounceCount { get; set; }

        [JsonProperty("bounced_soft")]
        public int SoftBounceCount { get; set; }

        [JsonProperty("bounced_date")]
        public DateTime? DateMostRecentBounce { get; set; }

        [JsonProperty("ip")]
        public string IPAddress { get; set; }

        [JsonProperty("Hash")]
        public string Hash { get; set; }

        [JsonProperty("socialdata_lastcheck")]
        public DateTime? DateSocialDataLastCheck { get; set; }

        [JsonProperty("lid")]
        public string LId { get; set; }

        [JsonProperty("name")]
        public string FullName { get; set; }

        [JsonProperty("a_unsub_date")]
        public DateTime? DateAUnsubDate { get; set; }

        [JsonProperty("a_unsub_time")]
        public string TimeAUnsub { get; set; }

        [JsonProperty("lists")]
        public Dictionary<int,Lists.ListResult> Lists { get; set; }

        [JsonProperty("listslist")]
        public string ListString { get; set; }

        [JsonProperty("fields")]
        public Dictionary<int,Fields.FieldResult> Fields { get; set; }

        [JsonProperty("actions")]
        public ContactActionResult[] Actions { get; set; }

        [JsonProperty("bounces")]
        public Bounces.BouncesResult Bounces { get; set; }

        [JsonProperty("bouncescnt")]
        public int BouncesCount { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

    }
}
