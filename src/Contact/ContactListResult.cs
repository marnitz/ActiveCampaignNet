using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Contact
{
    public class ContactListResult :ApiResult
    {
        [JsonProperty("0")]
        public ContactViewResult Contact0 { get; set; }
        [JsonProperty("1")]
        public ContactViewResult Contact1 { get; set; }
        [JsonProperty("2")]
        public ContactViewResult Contact2 { get; set; }
        [JsonProperty("3")]
        public ContactViewResult Contact3 { get; set; }
        [JsonProperty("4")]
        public ContactViewResult Contact4 { get; set; }
        [JsonProperty("5")]
        public ContactViewResult Contact5 { get; set; }
        [JsonProperty("6")]
        public ContactViewResult Contact6 { get; set; }
        [JsonProperty("7")]
        public ContactViewResult Contact7 { get; set; }
        [JsonProperty("8")]
        public ContactViewResult Contact8 { get; set; }
        [JsonProperty("9")]
        public ContactViewResult Contact9 { get; set; }
        [JsonProperty("10")]
        public ContactViewResult Contact10 { get; set; }
        [JsonProperty("11")]
        public ContactViewResult Contact11 { get; set; }
        [JsonProperty("12")]
        public ContactViewResult Contact12 { get; set; }
        [JsonProperty("13")]
        public ContactViewResult Contact13 { get; set; }
        [JsonProperty("14")]
        public ContactViewResult Contact14 { get; set; }
        [JsonProperty("15")]
        public ContactViewResult Contact15 { get; set; }
        [JsonProperty("16")]
        public ContactViewResult Contact16 { get; set; }
        [JsonProperty("17")]
        public ContactViewResult Contact17 { get; set; }
        [JsonProperty("18")]
        public ContactViewResult Contact18 { get; set; }
        [JsonProperty("19")]
        public ContactViewResult Contact19 { get; set; }
    }
}
