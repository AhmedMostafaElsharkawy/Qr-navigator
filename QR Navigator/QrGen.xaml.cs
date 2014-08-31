using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;
using System.Windows.Media.Imaging;
using System.Windows.Media;
namespace QR_Navigator
{
    public partial class QrGen : PhoneApplicationPage
    {
        public QrGen()
        {
            InitializeComponent();
        }

        private void txtTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            QrImage.Source = ALLgenqr();
        }

      private   WriteableBitmap ALLgenqr()
        {
            QRCodeWriter _writer = new QRCodeWriter();
            com.google.zxing.common.ByteMatrix matrix;
            // QrImage.Source.SetValue== 
            var barcodeImage = _writer.encode(txtTitle.Text, BarcodeFormat.QR_CODE, 400, 400);
          
            return barcodeImage;

        }

        private string  rr()
        {
            QRCodeWriter writer = new QRCodeWriter();
            com.google.zxing.common.ByteMatrix matrix;

            int size = 180;
            matrix = writer.encode("MECARD:N:Owen,Sean;ADR:76 9th Avenue, 4th Floor, New York, NY 10011;TEL:+12125551212;EMAIL:srowen@example.com;; ", BarcodeFormat.QR_CODE, size, size, null);


            BitmapImage img = new BitmapImage();
            Color Color = System.Windows.Media.Color.FromArgb(0,0,0,0);

            for (int y = 0; y < matrix.Height; ++y)
            {
                for (int x = 0; x < matrix.Width; ++x)
                {
                    Color pixelColor = img.(x, y);

                    //Find the colour of the dot
                    if (matrix.get_Renamed(x, y) == -1)
                    {
                        img.GetValue (x, y,  Colors.White);
                    }
                    else
                    {
                        img.SetPixel(x, y, Colors.Black );
                    }
                }
            }
    }
    }
}