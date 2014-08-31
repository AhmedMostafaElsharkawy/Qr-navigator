using System;
using System.Windows.Threading;
using System.Windows.Navigation;
using System.Collections.ObjectModel;

using Microsoft.Devices;
using com.google.zxing;
using com.google.zxing.common;
using com.google.zxing.qrcode;
using Microsoft.Phone.Tasks;
namespace QR_Navigator
{
    public partial class MainPage
    {
        private readonly DispatcherTimer _timer;
        private readonly ObservableCollection<string> _matches;

        private PhotoCameraLuminanceSource _luminance;
        private QRCodeReader _reader;
        private PhotoCamera _photoCamera;
        
        public MainPage()
        {            
            InitializeComponent();

            _matches = new ObservableCollection<string>();
            _matchesList.ItemsSource = _matches;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(250);
            _timer.Tick += (o, arg) => ScanPreviewBuffer();
     
           
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            _photoCamera = new PhotoCamera();
            _photoCamera.Initialized += OnPhotoCameraInitialized;            
            _previewVideo.SetSource(_photoCamera);

            CameraButtons.ShutterKeyHalfPressed += (o, arg) => _photoCamera.Focus();

            base.OnNavigatedTo(e);
        }

        private void OnPhotoCameraInitialized(object sender, CameraOperationCompletedEventArgs e)
        {
            int width = Convert.ToInt32(_photoCamera.PreviewResolution.Width);
            int height = Convert.ToInt32(_photoCamera.PreviewResolution.Height);
            
            _luminance = new PhotoCameraLuminanceSource(width, height);
            _reader = new QRCodeReader();

            Dispatcher.BeginInvoke(() => {
                _previewTransform.Rotation = _photoCamera.Orientation;
                _timer.Start();
            });
        }
 
        private void ScanPreviewBuffer()
        {
            try
            {
                _photoCamera.GetPreviewBufferY(_luminance.PreviewBufferY);
                var binarizer = new HybridBinarizer(_luminance);
                var binBitmap = new BinaryBitmap(binarizer);
                var result = _reader.decode(binBitmap);
                Dispatcher.BeginInvoke(() => DisplayResult(result.Text));
            }
            catch
            {
             
            }            
        }

        private void DisplayResult(string text)
        {
            if (!_matches.Contains(text))
                _matches.Add(text);
                share.qrVal = text;
                _timer.Stop();
                _photoCamera.CancelFocus();
                _photoCamera.Dispose();
            NavigationService.Navigate(new Uri("/NaVigator.xaml", UriKind.Relative));
        }

        //private void _matchesList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)

        //{
        //    try
        //    {
        //        share.qrVal = (_matchesList.SelectedItem).ToString();
        //        _timer.Stop();
        //        _photoCamera.CancelFocus();
        //        _photoCamera.Dispose();
        //        NavigationService.Navigate(new Uri("/NaVigator.xaml", UriKind.Relative));
        //    }
        //    catch { }
             
        //}

        private void _matchesList_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
            {
                share.qrVal = (_matchesList.SelectedItem).ToString();
                _timer.Stop();
                _photoCamera.CancelFocus();
                _photoCamera.Dispose();
                NavigationService.Navigate(new Uri("/NaVigator.xaml", UriKind.Relative));
            }
            catch { }
        }

        private void appBarOkButton_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/NaVigator.xaml", UriKind.Relative));

        }

  
     
    }
}

public static  class share
{
    public static string qrVal = "";
    public static string UrlVal; 
}