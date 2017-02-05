using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Filters
{
    public class FilterOptions
    {
        public List<int> ContactIds { get; set; }
        public List<string> Email { get; set; }
        public List<int> ListIDs { get; set; }
        public List<string> FirstName { get; set; }
        public List<string> LastName { get; set; }
        public List<string> Organization { get; set; }
        public int? IDGreater { get; set; }
        public int? IDLess { get; set; }
        public int? SegmentId { get; set; }
        public List<int> Status { get; set; }
        public int[] TagId { get; set; }
        public string TagName { get; set; }
        public DateTime? DateAt { get; set; }
        public DateTime? DateSince { get; set; }
        public DateTime? DateUntil { get; set; }
        public Dictionary<int, string> CustomFields { get; set; }
        public Dictionary<string, string> CustomFieldsByTags { get; set; }
    }
}
