using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Contact
{
    public class ContactFilters
    {
        /**
         * List of ID's, null for all
         */
        public List<int> IDs { get; set; }

        public Filters.FilterOptions Filters { get; set; }

        public bool FullData { get; set; }

        public bool SortDirection { get; set; }

        public int PageNumber { get; set; }

    }
}
