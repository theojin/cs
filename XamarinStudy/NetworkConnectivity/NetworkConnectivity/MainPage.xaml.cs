using Plugin.Connectivity;
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

// 빈 페이지 항목 템플릿에 대한 설명은 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x412에 나와 있습니다.

namespace NetworkConnectivity
{
    /// <summary>
    /// 자체적으로 사용하거나 프레임 내에서 탐색할 수 있는 빈 페이지입니다.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public BookManager BookManager { get; set; } = new BookManager();
        public MainPage()
        {
            this.InitializeComponent();


            //CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
            //UpdateNetworkInfo();
            //Test();
        }

        private async void Test()
        {
            var bookManager = new BookManager();
            await bookManager.GetAll();
        }

        //private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        //{
        //    UpdateNetworkInfo();
        //}

        //public void UpdateNetworkInfo()
        //{
        //    NetworkStatusTextBlock.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "Disconnected";
        //    NetworkTypeTextBlock.Text = CrossConnectivity.Current.ConnectionTypes.ToList().Count > 0 ?
        //        CrossConnectivity.Current.ConnectionTypes.ToList()[0].ToString() : "No types";
        //}
    }
}
