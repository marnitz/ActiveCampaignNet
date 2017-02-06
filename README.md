# ActiveCampaignNet
Forked from https://github.com/Selz/ActiveCampaignNet
The intention is to add an object model wrapper to make calling the API easier.

# Examples

## Usage

```csharp
//Initialise
 string YourKey = "";
 string YourBaseURL = "";
 var x = new ActiveCampaignNet.ActiveCampaignClient(YourKey,YourBaseURL);

//AccountView
 var z = x.AccountView.AccountView();
 MessageBox.Show(z.FirstName + " " + z.LastName + " " + z.SubscriberLimit.ToString());

//Fetch a contact by id
 var contact = x.Contact.ContactView(1);
 MessageBox.Show(contact.FullName);

//Fetch contacts with a specific tag
 var zz = x.Contact.ContactList(o => {
     o.TagId = new int[] { 1,2 };                
 });

 var msg = zz.Select(o => string.Format("{0} -> {1} : {2}", o.Id, o.FullName,string.Join(",",o.Tags)));
 MessageBox.Show(string.Join("\r\n",msg));
```

The wrapper is very minimilistic in its current form as most of the API has not been mapped. 
However, this may help others

# Implemented Calls
- account_view
- contact_list
- contact_view
- list_list
- tags_list
