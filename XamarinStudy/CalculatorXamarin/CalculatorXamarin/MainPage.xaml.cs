using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorXamarin
{
    public partial class MainPage : ContentPage
    {
        public enum CalculatorState
        {
            Initial,
            FistNumber,
            SecondNumber,
        }

        public CalculatorState State { get; set; }

        private int firstNumber;
        private string opr;

        public MainPage()
        {
            InitializeComponent();
        }

        private void NumberButton_Clicked(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            int.TryParse(button.Text, out int number);

            if (State == CalculatorState.Initial)
            {
                ResultLabel.Text = string.Empty;
                State = CalculatorState.FistNumber;
            }
            else if (State == CalculatorState.SecondNumber && ResultLabel.Text == "0")
            {
                ResultLabel.Text = string.Empty;
            }

            ResultLabel.Text += number;

            var colors = new string[] { "#FFA500", "#CCFF55", "#AA3399" };
            var random = new Random();
            var index = random.Next(3);
            var color = colors[index];

            Resources["OperatorColor"] = Color.FromHex(color);
        }

        private void OperatorButton_Clicked(object sender, EventArgs e)
        {
            if (!(sender is Button button))
                return;

            int.TryParse(ResultLabel.Text, out int number);

            if (State == CalculatorState.FistNumber)
            {
                firstNumber = number;
                State = CalculatorState.SecondNumber;
                opr = button.Text;

                ResultLabel.Text = "";
            }
        }

        private void ClearButton_Clicked(object sender, EventArgs e)
        {
            firstNumber = 0;
            opr = string.Empty;
            State = CalculatorState.Initial;
            ResultLabel.Text = "";
        }

        private void CalculateButton_Clicked(object sender, EventArgs e)
        {
            if (State != CalculatorState.SecondNumber)
                return;

            int.TryParse(ResultLabel.Text, out int secondNumber);

            int result;
            switch (opr)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "x":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    result = firstNumber / secondNumber;
                    break;
                default:
                    result = 0;
                    break;
            }

            ResultLabel.Text = result.ToString();

            firstNumber = result;
            opr = "";
            State = CalculatorState.FistNumber;
        }
    }
}
