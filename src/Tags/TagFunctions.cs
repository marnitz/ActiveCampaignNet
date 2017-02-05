using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveCampaignNet.Tags
{
    public class TagWrapper : ActiveCampaignFunctionWrapper
    {
        public TagWrapper(ActiveCampaignClient client) : base(client) { }

        public void List() 
        {
            var result =_client.ApiArray<TagListResult>("tags_list", null);
        }
    }
}
