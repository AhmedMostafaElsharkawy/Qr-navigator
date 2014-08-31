using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;
namespace QR_Navigator
{
    public partial class Browser : PhoneApplicationPage
    {
        public Browser()
        {
            InitializeComponent();
            BrowserProgressBar.Visibility = System.Windows.Visibility.Visible;
            FeedBrowser.Navigate(new Uri(share.UrlVal, UriKind.Absolute));
        }
      
       public  string site="";
        private void btnRead_Click(object sender, EventArgs e)
        {
            ActiveReadMode();
        }
        //private void browser_Loaded(object sender, RoutedEventArgs e)
        //{
        //     BrowserProgressBar.Visibility = System.Windows .Visibility.Visible;
        //     FeedBrowser.Navigate(new Uri(share. UrlVal, UriKind.Absolute));
        //}

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (NavigationService.CanGoBack)
                {
                    NavigationService.GoBack();
                }
            }
            catch 
            {
                
            }
               
            }

        private void FeedBrowser_LoadCompleted(object sender, NavigationEventArgs e)
        {
            BrowserProgressBar.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
       ShareLinkTask  myShareLansher = new ShareLinkTask();
  myShareLansher.LinkUri = new Uri (share.UrlVal );
        myShareLansher.Show();
        }
          void  ActiveReadMode()
          {
        FeedBrowser.IsScriptEnabled = true;
        BrowserProgressBar.Visibility = System .Windows.Visibility.Visible;
        site = "javascript:(%28function%28%29%7Bwindow.baseUrl%3D%27http%3A//www.readability.com%27%3Bwindow.readabilityToken%3D%27%27%3Bvar%20s%3Ddocument.createElement%28%27script%27%29%3Bs.setAttribute%28%27type%27%2C%27text/javascript%27%29%3Bs.setAttribute%28%27charset%27%2C%27UTF-8%27%29%3Bs.setAttribute%28%27src%27%2CbaseUrl%2B%27/bookmarklet/read.js%27%29%3Bdocument.documentElement.appendChild%28s%29%3B%7D%29%28%29)";
        FeedBrowser.Navigate(new Uri(site, UriKind.Absolute));
      
          }

          private void FeedBrowser_Navigating(object sender, NavigatingEventArgs e)
          {
              BrowserProgressBar.Visibility = System.Windows.Visibility.Visible;
          }

          private void OnOrientationChanged(object sender, OrientationChangedEventArgs e)
          {
              if ((e.Orientation & PageOrientation.Portrait) == (PageOrientation.Portrait))
              {
                  LayoutRoot.Margin = new Thickness(0, 0, 0, 0);
              }
              else if ((e.Orientation & PageOrientation.LandscapeLeft) == (PageOrientation.LandscapeLeft))
              {
                  LayoutRoot.Margin = new Thickness(0, 0, 35, 0);
              }
              else if ((e.Orientation & PageOrientation.LandscapeRight) == (PageOrientation.LandscapeRight))
              {
                  LayoutRoot.Margin = new Thickness(35, 0, 0, 0);
              }
          }

          private void btnOpenOnIE(object sender, EventArgs e)
          {
              WebBrowserTask webBrowserTask = new WebBrowserTask();
              webBrowserTask.Uri = new Uri(share. UrlVal, UriKind.Absolute);
              webBrowserTask.Show();
          }

          private void btnLater_Click(object sender, EventArgs e)
          {
              if (!share.qrVal.StartsWith("http://"))
              {
                  share.qrVal = "http://" +share.qrVal ;
              }
              FeedBrowser.Navigate(new Uri("http://readability.com/save?url=" + share.qrVal  , UriKind.Absolute));
          }
        
        }
    }

