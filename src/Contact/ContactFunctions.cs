using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Linq.Expressions;

namespace ActiveCampaignNet.Contact
{
    public class ContactWrapper : ActiveCampaignFunctionWrapper
    {
        public ContactWrapper(ActiveCampaignClient client) : base(client) { }

        public ContactViewResult ContactView(int ContactId)
        {
            return _client.Api<ContactViewResult>("contact_view", new NameValueCollection
                {
                    {"id", ContactId.ToString()}
                });
        }

        public List<ContactViewResult> ContactList(Action<Filters.FilterOptions> options)
        {
            var _options = new Filters.FilterOptions();
            options(_options);

            var nvc = new NameValueCollection();

            if (_options.FirstName != null && _options.FirstName.Count > 0)
                nvc.Add("filters[first_name]", string.Join<string>(",", _options.FirstName));

            if (_options.LastName != null && _options.LastName.Count > 0)
                nvc.Add("filters[last_name]", string.Join<string>(",", _options.LastName));

            if (_options.Email != null && _options.Email.Count > 0)
                nvc.Add("filters[email]", string.Join<string>(",", _options.Email));

            if (_options.ListIDs != null && _options.ListIDs.Count > 0)
                nvc.Add("filters[listid]", string.Join<int>(",", _options.ListIDs));

            if (_options.Organization != null && _options.Organization.Count > 0)
                nvc.Add("filters[organization]", string.Join<string>(",", _options.Organization));

            if (_options.IDGreater.HasValue)
                nvc.Add("filters[idgreater]", _options.IDGreater.Value.ToString());

            if (_options.IDLess.HasValue)
                nvc.Add("filters[idless]", _options.IDLess.Value.ToString());

            if (_options.SegmentId.HasValue)
                nvc.Add("filters[segmentid]", _options.SegmentId.ToString());

            if (_options.Status != null && _options.Status.Count > 0)
                nvc.Add("filters[status]", string.Join<int>(",", _options.Status));

            if (_options.TagId != null && _options.TagId.Length > 0)
            {
                string tags = "";
                foreach (int tag in _options.TagId)
                    tags += "," + tag.ToString();
                tags = tags.Substring(1);
                nvc.Add("filters[tagid]", tags);
            }
            else if (_options.TagName != null)
                nvc.Add("filters[tagname]", _options.TagName);

            if (_options.DateAt.HasValue)
                nvc.Add("filters[datetime]", _options.DateAt.Value.ToString("yyyy-MM-dd"));

            if (_options.DateSince.HasValue)
                nvc.Add("filters[since_datetime]", _options.DateSince.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            if (_options.DateUntil.HasValue)
                nvc.Add("filters[until_datetime]", _options.DateUntil.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            if (_options.CustomFieldsByTags != null)
            {
                foreach (var custom in _options.CustomFieldsByTags)
                {
                    nvc.Add(string.Format("filters[fields][%{0}%]", custom.Key), custom.Value);
                }
            }

            if (_options.CustomFields != null)
            {
                foreach (var custom in _options.CustomFields)
                {
                    nvc.Add(string.Format("filters[fields][%{0}%]", custom.Key), custom.Value);
                }
            }

            //Only set the ids option if no filter is set
            if (nvc.Count == 0)
            {
                if (_options.ContactIds == null || _options.ContactIds.Count == 0)
                    nvc.Add("ids", "ALL");
                else
                    nvc.Add("ids", string.Join<int>(",", _options.ContactIds));
            }
            
            var result = _client.Api<ContactListResult>("contact_list", nvc);
            List<ContactViewResult> ret = new List<ContactViewResult>();
            if (result.Contact0 != null) ret.Add(result.Contact0);
            if (result.Contact1 != null) ret.Add(result.Contact1);
            if (result.Contact2 != null) ret.Add(result.Contact2);
            if (result.Contact3 != null) ret.Add(result.Contact3);
            if (result.Contact4 != null) ret.Add(result.Contact4);
            if (result.Contact5 != null) ret.Add(result.Contact5);
            if (result.Contact6 != null) ret.Add(result.Contact6);
            if (result.Contact7 != null) ret.Add(result.Contact7);
            if (result.Contact8 != null) ret.Add(result.Contact8);
            if (result.Contact9 != null) ret.Add(result.Contact9);
            if (result.Contact10 != null) ret.Add(result.Contact10);
            if (result.Contact11 != null) ret.Add(result.Contact11);
            if (result.Contact12 != null) ret.Add(result.Contact12);
            if (result.Contact13 != null) ret.Add(result.Contact13);
            if (result.Contact14 != null) ret.Add(result.Contact14);
            if (result.Contact15 != null) ret.Add(result.Contact15);
            if (result.Contact16 != null) ret.Add(result.Contact16);
            if (result.Contact17 != null) ret.Add(result.Contact17);
            if (result.Contact18 != null) ret.Add(result.Contact18);
            if (result.Contact19 != null) ret.Add(result.Contact19);

            return ret;
        }


    }
}
