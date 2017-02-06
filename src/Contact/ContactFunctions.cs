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


        private NameValueCollection GetContactDataFromAction(Contact c)
        {

            if (string.IsNullOrEmpty(c.Email))
                throw new ArgumentException("Missing required field: Email");

            var nvc = new NameValueCollection();

            if (c.Id.HasValue)
                nvc.Add("id", c.Id.ToString());
            
            if (!string.IsNullOrEmpty(c.FirstName))
                nvc.Add("first_name", c.FirstName);

            if (!string.IsNullOrEmpty(c.LastName))
                nvc.Add("last_name", c.LastName);

            nvc.Add("email", c.Email);

            if (!string.IsNullOrEmpty(c.Phone))
                nvc.Add("phone", c.Phone);

            if (!string.IsNullOrEmpty(c.OrganizationName))
                nvc.Add("orgname", c.OrganizationName);

            if (c.Tags != null && c.Tags.Length > 0)
                nvc.Add("tags", string.Join<string>(",", c.Tags));

            if (!string.IsNullOrEmpty(c.IPv4))
                nvc.Add("ipv4", c.IPv4);

            if (c.CustomFields != null && c.CustomFields.Count > 0)
            {
                foreach (var key in c.CustomFields.Keys)
                {
                    nvc.Add(string.Format("field[{0},0]", key), c.CustomFields[key]);
                }
            }

            if (c.PersonilizationTags != null && c.PersonilizationTags.Count > 0)
            {
                foreach (var key in c.PersonilizationTags.Keys)
                {
                    nvc.Add(string.Format("field[%{0}%,0]", key), c.PersonilizationTags[key]);
                }
            }

            if (c.Lists != null && c.Lists.Length > 0)
            {
                foreach (var list in c.Lists)
                {
                    nvc.Add(string.Format("p[{0}]", list), list.ToString());
                }
            }

            if (c.ListStatus != null && c.ListStatus.Count > 0)
            {
                foreach (var key in c.ListStatus.Keys)
                {
                    nvc.Add(string.Format("status[{0}]", key), ((int)c.ListStatus[key]).ToString());
                }
            }

            if (c.Form != null && c.Form > 0)
                nvc.Add("form", c.Form.Value.ToString());


            if (c.NoResponders != null && c.NoResponders.Count > 0)
            {
                foreach (var key in c.NoResponders.Keys)
                {
                    nvc.Add(string.Format("noresponders[{0}]", key), (c.NoResponders[key] ? 1 : 0).ToString());
                }
            }

            if (c.ListSubscribedDate != null && c.ListSubscribedDate.Count > 0)
            {
                foreach (var key in c.ListSubscribedDate.Keys)
                {
                    nvc.Add(string.Format("sdate[{0}]", key), c.ListSubscribedDate[key].ToString("yyyy-MM-dd HH:mm:ss"));
                }
            }

            if (c.InstantResponders != null && c.InstantResponders.Count > 0)
            {
                foreach (var key in c.InstantResponders.Keys)
                {
                    if (c.ListStatus == null || !c.ListStatus.ContainsKey(key) || c.ListStatus[key] == Fields.Enums.ActiveUnsubscribed.Unsubscribed)
                        throw new ArgumentException(string.Format("Cannot send an instant responder for list {0} as it was not subscrbed to", key));
                    nvc.Add(string.Format("instantresponders[{0}]", key), (c.InstantResponders[key] ? 1 : 0).ToString());
                }
            }

            if (c.LastMessage != null && c.LastMessage.Count > 0)
            {
                foreach (var key in c.LastMessage.Keys)
                {
                    nvc.Add(string.Format("lastmessage[{0}]", key), (c.LastMessage[key] ? 1 : 0).ToString());
                }
            }

            return nvc;
        }

        public ContactResult AddContact(Action<Contact> ContactAction)
        {
            var c = new Contact();
            ContactAction(c);
            var nvc = GetContactDataFromAction(c);
            var result = _client.Api<ContactResult>("contact_add", nvc);
            return result;
        }

        public ContactResult EditContact(Action<Contact> ContactAction)
        {
            var c = new Contact();
            ContactAction(c);
            if (!c.Id.HasValue) throw new ArgumentException("Missing contact id");
            if (c.Lists == null || c.Lists.Length == 0) throw new ArgumentException("You must specify a list");
            var nvc = GetContactDataFromAction(c);
            var result = _client.Api<ContactResult>("contact_edit", nvc);
            return result;
        }

        public ApiResult SyncContact(Action<Contact> ContactAction)
        {
            var c = new Contact();
            ContactAction(c);
            var nvc = GetContactDataFromAction(c);
            var result = _client.Api<ApiResult>("contact_sync", nvc);
            return result;
        }

        public ContactViewResult ContactViewEmail(string Email)
        {
            return _client.Api<ContactViewResult>("contact_view_email", new NameValueCollection
                {
                    {"email", Email}
                });
        }

        public ContactViewResult ContactViewHash(string Hash)
        {
            return _client.Api<ContactViewResult>("contact_view_hash", new NameValueCollection
                {
                    {"hash", Hash}
                });
        }

        public ApiResult AddTags(string Email, string[] Tags)
        {
            var nmv = new NameValueCollection
                {
                    {"email", Email}
                };
            if (Tags.Length == 1)
                nmv.Add("tags", Tags[0]);
            else
            {
                int c = 0;
                foreach (var t in Tags)
                {
                    nmv.Add("tags[" + c.ToString() + "]", t);
                    c++;
                }
            }
            return _client.Api<ApiResult>("contact_tag_add", nmv);
        }

        public ApiResult AddTags(int Id, string[] Tags)
        {
            var nmv = new NameValueCollection
                {
                    {"id", Id.ToString()}
                };
            if (Tags.Length == 1)
                nmv.Add("tags", Tags[0]);
            else
            {
                int c = 0;
                foreach (var t in Tags)
                {
                    nmv.Add("tags[" + c.ToString() + "]", t);
                    c++;
                }
            }
            return _client.Api<ApiResult>("contact_tag_add", nmv);
        }

        public ApiResult RemoveTags(string Email, string[] Tags)
        {
            var nmv = new NameValueCollection
                {
                    {"email", Email}
                };
            if (Tags.Length == 1)
                nmv.Add("tags", Tags[0]);
            else
            {
                int c = 0;
                foreach (var t in Tags)
                {
                    nmv.Add("tags[" + c.ToString() + "]", t);
                    c++;
                }
            }
            return _client.Api<ApiResult>("contact_tag_remove", nmv);
        }

        public ApiResult RemoveTags(int Id, string[] Tags)
        {
            var nmv = new NameValueCollection
                {
                    {"id", Id.ToString()}
                };
            if (Tags.Length == 1)
                nmv.Add("tags", Tags[0]);
            else
            {
                int c = 0;
                foreach (var t in Tags)
                {
                    nmv.Add("tags[" + c.ToString() + "]", t);
                    c++;
                }
            }
            return _client.Api<ApiResult>("contact_tag_remove", nmv);
        }

        public ApiResult Delete(int Id)
        {
            return _client.Api<ApiResult>("contact_delete", new NameValueCollection
                {
                    {"id", Id.ToString()}
                });
        }

        public ApiResult DeleteList(int[] Ids)
        {
            return _client.Api<ApiResult>("contact_delete_list", new NameValueCollection
                {
                    {"ids", string.Join<int>(",",Ids)}
                });
        }

        public ApiResult DeleteNote(int NoteId)
        {
            return _client.Api<ApiResult>("contact_note_delete", new NameValueCollection
                {
                    {"noteid", NoteId.ToString()}
                });
        }

        //contact_automation_list
        //contact_note_add
        //contact_note_edit
        //contact_paginator
    }
}
