using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LB5_2
{
    public partial class MainWindow : Window
    {
        private readonly Dictionary<string, double> fuelPrices = new Dictionary<string, double>();
        private double totalRevenue = 0.0;

        public MainWindow()
        {
            InitializeComponent();
            SetupFuel();
            SetInitialStates();
        }

        private void SetupFuel()
        {
            fuelPrices.Clear();
            fuelPrices.Add("A-92", 50.40);
            fuelPrices.Add("A-95", 54.50);
            fuelPrices.Add("Дизель", 52.10);

            FuelComboBox.ItemsSource = fuelPrices.Keys;
            FuelComboBox.SelectedIndex = 0;

            // Встановлюємо початкову ціну
            if (FuelComboBox.SelectedItem != null)
            {
                string key = FuelComboBox.SelectedItem.ToString();
                if (fuelPrices.TryGetValue(key, out double price))
                {
                    PriceTextBox.Text = price.ToString("F2");
                }
            }
        }

        private void SetInitialStates()
        {
            if (QuantityRadio != null && SumRadio != null)
            {
                QuantityTextBox.IsEnabled = QuantityRadio.IsChecked == true;
                SumTextBox.IsEnabled = SumRadio.IsChecked == true;
            }
        }

        private void FuelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelComboBox.SelectedItem == null) return;

            string key = FuelComboBox.SelectedItem.ToString();
            if (fuelPrices.TryGetValue(key, out double price))
            {
                PriceTextBox.Text = price.ToString("F2");
            }
        }

        private void Radio_Checked(object sender, RoutedEventArgs e)
        {
            if (QuantityTextBox == null || SumTextBox == null) return;

            if (QuantityRadio.IsChecked == true)
            {
                QuantityTextBox.IsEnabled = true;
                SumTextBox.IsEnabled = false;
                SumTextBox.Text = "0";
            }
            else
            {
                QuantityTextBox.IsEnabled = false;
                QuantityTextBox.Text = "0";
                SumTextBox.IsEnabled = true;
            }
        }

        private void CafeCheck_Changed(object sender, RoutedEventArgs e)
        {
            if (HotDogQuantity != null)
                HotDogQuantity.IsEnabled = HotDogCheck.IsChecked == true;

            if (HamburgerQuantity != null)
                HamburgerQuantity.IsEnabled = HamburgerCheck.IsChecked == true;

            if (HotDogCheck.IsChecked == false && HotDogQuantity != null)
                HotDogQuantity.Text = "0";

            if (HamburgerCheck.IsChecked == false && HamburgerQuantity != null)
                HamburgerQuantity.Text = "0";
        }

        private double ParseDouble(string text)
        {
            if (string.IsNullOrWhiteSpace(text)) return 0;

            // Заміна коми на крапку
            text = text.Replace(',', '.');
            if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out double value))
                return value;
            return 0;
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            double fuelTotal = 0.0;
            double cafeTotal = 0.0;

            // ПАЛЬНЕ 
            if (FuelComboBox.SelectedItem != null)
            {
                string key = FuelComboBox.SelectedItem.ToString();
                if (fuelPrices.TryGetValue(key, out double price))
                {
                    if (QuantityRadio.IsChecked == true)
                    {
                        double quantity = ParseDouble(QuantityTextBox.Text);
                        fuelTotal = price * quantity;
                    }
                    else
                    {
                        double sum = ParseDouble(SumTextBox.Text);
                        fuelTotal = sum;
                        double liters = price != 0 ? sum / price : 0;
                        QuantityTextBox.Text = liters.ToString("F2");
                    }
                }
            }
            FuelTotalLabel.Text = $"{fuelTotal:F2} грн.";

            //  МІНІ-КАФЕ 
            if (HotDogCheck.IsChecked == true)
            {
                double price = ParseDouble(HotDogPrice.Text);
                double qty = ParseDouble(HotDogQuantity.Text);
                cafeTotal += price * qty;
            }

            if (HamburgerCheck.IsChecked == true)
            {
                double price = ParseDouble(HamburgerPrice.Text);
                double qty = ParseDouble(HamburgerQuantity.Text);
                cafeTotal += price * qty;
            }

            CafeTotalLabel.Text = $"{cafeTotal:F2} грн.";

            //  ВСЬОГО 
            double total = fuelTotal + cafeTotal;
            GrandTotalLabel.Text = $"{total:F2} грн.";
            totalRevenue += total;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show($"Загальна виручка за день: {totalRevenue:F2} грн.", "Кінець дня");
            base.OnClosing(e);
        }
    }
}