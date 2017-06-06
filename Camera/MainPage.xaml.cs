using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Media.Capture;
using Windows.ApplicationModel;
using System.Threading.Tasks;
using Windows.System.Display;
using Windows.Graphics.Display;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace Camera
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private WebCamHelper camera;
        public MainPage()
        {
            this.InitializeComponent();
            initAsync();
        }

        public async void initAsync()
        {
            if (camera == null)
            {
                camera = new WebCamHelper();
                await camera.InitializeCameraAsync();
                cameraElement.Source = camera.mediaCapture;
                photoAsync();
            }

        }

        public  void photoAsync()
        {
            if (camera.IsInitialized())
            {
                tbMessage.Text = "success";
            //    await TakePhotoAsync();
                camera.StartCameraPreview();
            }
        }

        public async Task TakePhotoAsync()
        {
            if (!camera.IsInitialized()) return;
            StorageFile imgFile = await camera.CapturePhoto();
        }

        private void cameraElement_Loaded(object sender, RoutedEventArgs e)
        {
            initAsync();
            
        }
    }
}
