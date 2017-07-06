using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DollarCalculatorXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            var isDollarInt = int.TryParse(DollarEntry.Text, out int dollar);
            var isRateInt = int.TryParse(ExchangeRateEntry.Text, out int rate);

            if (isDollarInt && isRateInt)
                ResultLabel.Text = (dollar * rate) + "원";
        }
    }
}
