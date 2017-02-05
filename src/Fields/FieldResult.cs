using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Fields
{
    public class FieldResult : ApiResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("Descript")]
        public string Descript { get; set; }

        [JsonProperty("isrequired")]
        public string IsRequired { get; set; }

        [JsonProperty("perstag")]
        public string PersonalTag { get; set; }

        [JsonProperty("defval")]
        public string DefaultValue { get; set; }

        [JsonProperty("show_in_list")]
        public int ShowInList { get; set; }

        [JsonProperty("rows")]
        public int Rows { get; set; }

        [JsonProperty("cols")]
        public int Cols { get; set; }

        [JsonProperty("visible")]
        public string Visible { get; set; }

        [JsonProperty("service")]
        public string Service { get; set; }

        [JsonProperty("ordernum")]
        public int OrderNum { get; set; }

        [JsonProperty("val")]
        public string Value { get; set; }

        [JsonProperty("relid")]
        public int? RelId { get; set; }

        [JsonProperty("dataid")]
        public int? DataId { get; set; }

        [JsonProperty("element")]
        public string Element { get; set; }

        [JsonProperty("options")]
        public List<OptionResult> Options { get; set; }

        [JsonProperty("selected")]
        public string Selected { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
