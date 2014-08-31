using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QRNavigatorData;
namespace QR_Navigator
{
    public partial class saveItLater : PhoneApplicationPage
    {
        public saveItLater()
        {
            InitializeComponent();
            txtContent.Text = dbHelper.QRVal;
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
                  QrHistory  NewQr = new QrHistory ();
            NewQr .Title =txtTitle  .Text .ToString ();
       NewQr.QrValue = txtContent.Text.ToString();
       dbHelper.SaveQRVal(NewQr);
        }

        private void appBarCancelButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NaVigator.xaml", UriKind.Relative));
        }
    }
}