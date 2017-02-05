using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet
{
    public abstract class ActiveCampaignFunctionWrapper
    {
        internal ActiveCampaignClient _client;
        public ActiveCampaignFunctionWrapper(ActiveCampaignClient client)
        {
            _client = client;
        }
    }
}
