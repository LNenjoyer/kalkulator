using System.ComponentModel.DataAnnotations;

namespace kalkulator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            OnClear(this, null);
        }
        string currentEntry = "";
        int currentState = 1;
        string mathOperator;
        double firstNumber, secondNumber;
        string decimalFormat = "N0";

        void OnWybranaLiczba(object sender, EventArgs e)
        {

            Button button = (Button)sender;
            string pressed = button.Text;

            currentEntry += pressed;

            if ((this.wynik.Text == "0" && pressed == "0")
                || (currentEntry.Length <= 1 && pressed != "0")
                || currentState < 0)
            {
                this.wynik.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }

            if (pressed == "." && decimalFormat != "N2")
            {
                decimalFormat = "N2";
            }

            this.wynik.Text += pressed;
        }
        void OnWybranyOperator(object sender, EventArgs e)
        {
            LockNumberValue(wynik.Text);

            currentState = -2;
            Button button = (Button)sender;
            string pressed = button.Text;
            mathOperator = pressed;
        }
        private void LockNumberValue(string text)
        {
            double number;
            if (double.TryParse(text, out number))
            {
                if (currentState == 1)
                {
                    firstNumber = number;
                }
                else
                {
                    secondNumber = number;
                }

                currentEntry = string.Empty;
            }
        }

        void OnWynik(object sender, EventArgs e)
        {
            if (currentState == 2)
            {
                if (secondNumber == 0)
                    LockNumberValue(wynik.Text);

                double result = Calculator.Calculator.Calculate(firstNumber, secondNumber, mathOperator);

                this.obecnie.Text = $"{firstNumber} {mathOperator} {secondNumber}";

                this.wynik.Text = Calculator.DoubleExtensions.ToTrimmedString(result,decimalFormat);
                firstNumber = result;
                secondNumber = 0;
                currentState = -1;
                currentEntry = string.Empty;
            }
        }

        void OnClear(object sender, EventArgs e)
        {
            firstNumber = 0;
            secondNumber = 0;
            currentState = 1;
            decimalFormat = "N0";
            this.wynik.Text = "0";
            currentEntry = string.Empty;
        }
    }
    

}
