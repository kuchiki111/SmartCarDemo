using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace SmartCarLocal
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            btnForward.AddHandler(PointerPressedEvent, new PointerEventHandler(btnForward_PointerPressed), true);
            btnForward.AddHandler(PointerReleasedEvent, new PointerEventHandler(btn_PointerReleased), true);

            btnRight.AddHandler(PointerPressedEvent, new PointerEventHandler(btnRight_PointerPressed), true);
            btnRight.AddHandler(PointerReleasedEvent, new PointerEventHandler(btn_PointerReleased), true);

            btnLeft.AddHandler(PointerPressedEvent, new PointerEventHandler(btnLeft_PointerPressed), true);
            btnLeft.AddHandler(PointerReleasedEvent, new PointerEventHandler(btn_PointerReleased), true);

            btnBackward.AddHandler(PointerPressedEvent, new PointerEventHandler(btnBackward_PointerPressed), true);
            btnBackward.AddHandler(PointerReleasedEvent, new PointerEventHandler(btn_PointerReleased), true);

            btnAround.AddHandler(PointerPressedEvent, new PointerEventHandler(btnAround_PointerPressed), true);
            btnAround.AddHandler(PointerReleasedEvent, new PointerEventHandler(btn_PointerReleased), true);
        }

        private SmartCar car;

        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            car = new SmartCar();
        }

        private void btn_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            if (car != null)
            {
                car.Stop();
            }
        }

        private void btnForward_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (car != null)
            {
                car.FowardBackword(Direction.Foward, 90);
            }
        }

        private void btnBackward_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (car != null)
            {
                car.FowardBackword(Direction.Backward, 90);
            }
        }

        private void btnRight_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (car != null)
            {
                car.TurnRight(90);
            }
        }

        private void btnLeft_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (car != null)
            {
                car.TurnLeft(90);
            }
        }

        private void btnAround_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (car != null)
            {
                car.TurnAround(90);
            }
        }

        private void btnAround_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
