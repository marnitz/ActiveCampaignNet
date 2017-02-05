using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string YourKey = "";
            string YourBaseURL = "";
            var x = new ActiveCampaignNet.ActiveCampaignClient(YourKey,YourBaseURL);
            
            var z = x.AccountView.AccountView();
            MessageBox.Show(z.FirstName + " " + z.LastName + " " + z.SubscriberLimit.ToString());
            
            var contact = x.Contact.ContactView(1);
            MessageBox.Show(contact.FullName);
            
            var zz = x.Contact.ContactList(o => {
                o.TagId = new int[] { 1,2 };                
            });

            var msg = zz.Select(o => string.Format("{0} -> {1} : {2}", o.Id, o.FullName,string.Join(",",o.Tags)));
            MessageBox.Show(string.Join("\r\n",msg));
        }
    }
}
