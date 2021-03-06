﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace Control
{
    public sealed partial class MainPage : Page
    {
        DatagramSocket socket = new DatagramSocket();
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
        }

        DataWriter writer;
        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtIPAddress.Text))
            {
                return;
            }

            await socket.ConnectAsync(new Windows.Networking.HostName(txtIPAddress.Text.Trim()), "8888");
            writer = new DataWriter(socket.OutputStream);

            Send("create");
            tbMessage.Text = "success";
        }

        private async void Send(string message)
        {
            try
            {
                writer.WriteString(message);

                //commit and send the data through the OutputStream
                await writer.StoreAsync();
            }
            catch (Exception ex)
            {
                writer = new DataWriter(socket.OutputStream);
                Debug.Write(ex.Message);
            }
            finally
            {

            }

        }

        private void btn_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Send("stop");
        }

        private void btnForward_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Send("forward");
        }

        private void btnBackward_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Send("backward");
        }

        private void btnRight_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Send("turnright");
        }

        private void btnLeft_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Send("turnleft");
        }

    }
}
