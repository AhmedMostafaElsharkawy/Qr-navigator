using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using QRNavigatorData;
namespace QR_Navigator
{
    public partial class NaVigator : PhoneApplicationPage
    {
        public NaVigator()
        {
            InitializeComponent();
            txtQrVal.Text = share.qrVal;
            txtQrVal.SelectAll();
        }
    
        private void btnAbout_Click(object sender, EventArgs e)
        {
            try
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri("https://www.facebook.com/ideasSoftware", UriKind.Absolute);
                webBrowserTask.Show();
            }
            catch { }
                 }

        private void btnSearchWithGoogle(object sender, GestureEventArgs e)
        {
            try
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri("http://www.google.com/search?q=" + share.qrVal, UriKind.Absolute);
                webBrowserTask.Show();
            }
            catch { }
        }

        private void btn_Sms(object sender, GestureEventArgs e)
        {
            try
            {
                SmsComposeTask smscomp = new SmsComposeTask();
                smscomp.Body = share.qrVal;
                smscomp.Show();
            }
            catch { }
         
        }

        private void btn_Mail(object sender, GestureEventArgs e)
        {
            try
            {
                EmailComposeTask email = new EmailComposeTask();
                email.Body = share.qrVal;
                email.Show();
            }
            catch { }
          
        }

        private void btnShare(object sender, GestureEventArgs e)
        {
            try
            {
                ShareLinkTask shareLink = new ShareLinkTask ();
                shareLink.LinkUri = new Uri(share.qrVal);
                shareLink.Message = share.qrVal;
                shareLink.Show();
            }
            catch { }
           
        }
        
        private void Readability_Click(object sender, GestureEventArgs e)
        {
            try
            {
                share.UrlVal = "http://readability.com/read?url=";
                if (!share.qrVal.StartsWith("http://"))
                {
                    share.UrlVal = "http://" + share.UrlVal ;
                }
                share.UrlVal = share.UrlVal + share.qrVal;
                NavigationService.Navigate(new Uri("/browser.xaml", UriKind.Relative));
            }
            catch { }
        }

        private void btnDial(object sender, GestureEventArgs e)
        {
            try
            {
                Microsoft.Phone.Tasks.PhoneCallTask calltask = new PhoneCallTask();
                calltask.PhoneNumber = share.qrVal;
                calltask.Show();
            }
            catch { }
        }

        private void instapaper_Click(object sender, GestureEventArgs e)
        {
            try
            {
                share.UrlVal = "http://www.instapaper.com/text?u=";
                if (!share.qrVal.StartsWith("http://"))
                {
                    share.UrlVal = "http://" + share.UrlVal ;
                }
                share.UrlVal = share.UrlVal + share.qrVal;
                NavigationService.Navigate(new Uri("/browser.xaml", UriKind.Relative));
            }
            catch { }
           

        }

        private void btnIE_Click(object sender, GestureEventArgs e)
        {
            try
            {
                WebBrowserTask webBrowserTask = new WebBrowserTask();
                webBrowserTask.Uri = new Uri(share.qrVal, UriKind.Absolute);
                webBrowserTask.Show();
            }
            catch { }
         

        }

        private void SaveItlater_Click(object sender, GestureEventArgs e)
        {
            dbHelper. CreateDatabase();
            dbHelper.QRVal = txtQrVal.Text .ToString();
            NavigationService.Navigate(new Uri("/saveItLater.xaml", UriKind.Relative));
        }
    }
}