using System;
using System.Globalization;
using System.Windows;

namespace LB5_1
{
    public partial class MainWindow : Window
    {
        double firstNumber = 0;
        string operation = "";
        bool isOperationClicked = false;

        public MainWindow()
        {
            InitializeComponent();
            
            txtInput.Text = "0";
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            string buttonContent = button.Content.ToString();

            if (isOperationClicked || txtInput.Text == "0")
            {
                txtInput.Text = "";
                isOperationClicked = false;
            }

            txtInput.Text += buttonContent;
        }

        private void Dot_Click(object sender, RoutedEventArgs e)
        {
           
            if (isOperationClicked)
            {
                txtInput.Text = "0";
                isOperationClicked = false;
            }

            if (!txtInput.Text.Contains("."))
            {
                txtInput.Text += ".";
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            string newOperation = button.Content.ToString();

            
            if (double.TryParse(txtInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double currentNumber))
            {
              
                if (!string.IsNullOrEmpty(operation) && !isOperationClicked)
                {
                   
                    Equals_Click(this, new RoutedEventArgs());
                    
                    double.TryParse(txtInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out firstNumber);
                }
                else
                {
                    firstNumber = currentNumber;
                }

                operation = newOperation;
               
                txtHistory.Text = $"{firstNumber.ToString(CultureInfo.InvariantCulture)} {operation}";
                isOperationClicked = true;
            }
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            
            if (double.TryParse(txtInput.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out double secondNumber))
            {
                double result = 0;
                switch (operation)
                {
                    case "+": result = firstNumber + secondNumber; break;
                    case "-": result = firstNumber - secondNumber; break;
                    case "*": result = firstNumber * secondNumber; break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            MessageBox.Show("Ділення на нуль заборонено!");
                            return;
                        }
                        result = firstNumber / secondNumber;
                        break;
                    default:
                        
                        result = secondNumber;
                        break;
                }

                
                txtHistory.Text = $"{firstNumber.ToString(CultureInfo.InvariantCulture)} {operation} {secondNumber.ToString(CultureInfo.InvariantCulture)} =";
                txtInput.Text = result.ToString(CultureInfo.InvariantCulture);

                // Скидаємо операцію для нового обчислення
                operation = "";
                isOperationClicked = true; // Дозволяє почати введення нового числа
            }
        }

        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
            txtHistory.Text = "";
            firstNumber = 0;
            operation = "";
            isOperationClicked = false;
        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Length > 0 && !isOperationClicked)
            {
                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            }
            // Якщо поле стало порожнім, повертаємо "0"
            if (txtInput.Text == "")
            {
                txtInput.Text = "0";
            }
        }
    }
}