using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ActiveCampaignNet.AccountView
{
    public class AccountViewWrapper:ActiveCampaignFunctionWrapper
    {
        public AccountViewWrapper(ActiveCampaignClient client) : base(client) { }

        public AccountViewResponse AccountView()
        {
            return _client.Api<AccountViewResponse>("account_view", null);
        }
    }
}
