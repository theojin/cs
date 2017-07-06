using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content;

namespace DollarCalculator
{
    [Activity(Label = "DollarCalculator", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        EditText dollarEditText, exchangeRateEditText;
        Button calculateButton, goNewButton, webButton;
        TextView resultTextView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);

            dollarEditText = FindViewById<EditText>(Resource.Id.dollarEditText);
            exchangeRateEditText = FindViewById<EditText>(Resource.Id.exchangeRateEditText);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            resultTextView = FindViewById<TextView>(Resource.Id.resultTextView);
            goNewButton = FindViewById<Button>(Resource.Id.GoNewButton);
            webButton = FindViewById<Button>(Resource.Id.webButton);

            calculateButton.Click += CalculateButton_Click;
            goNewButton.Click += GoNewButton_Click;
            webButton.Click += WebButton_Click;
        }

        private void WebButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent();
            intent.SetAction(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("http://www.daum.net"));
            StartActivity(intent);
        }

        private void GoNewButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(OtherActivity));
            StartActivity(intent);
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            var isDollar = int.TryParse(dollarEditText.Text, out int dollar);
            var isExchangeRateInt = int.TryParse(exchangeRateEditText.Text, out int exchangeRate);

            if (isDollar && isExchangeRateInt)
            {
                resultTextView.Text = (dollar * exchangeRate).ToString() + "원";
            }
        }
    }
}

