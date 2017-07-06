using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Phone
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void CallButton_Clicked(object sender, EventArgs e)
        {
            var number = NumberEntry.Text;
            //var dialer = DependencyService.Get<IDialer>();
            //await dialer.DialAsync(number);
            if (!CrossMessaging.Current.PhoneDialer.CanMakePhoneCall)
            {
                await DisplayAlert("Fail", "Cannot make a call in this device", "Confirm");
                return;
            }

            var result = await DisplayAlert("Success", $"{number}, you wanna call?", "Confirm", "Cancel");
            if (result) CrossMessaging.Current.PhoneDialer.MakePhoneCall(number);
        }
    }
}
