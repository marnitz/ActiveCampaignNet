using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Bounces
{
    public class BouncesResult : ApiResult
    {
        public string[] mailing { get; set; }
        public int mailings { get; set; }
        public string[] responder { get; set; }
        public int responders { get; set; }
    }
}
