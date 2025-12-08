using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Lb4
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       
        private void Task1_Click(object sender, RoutedEventArgs e)
        {
          
            if (sender is Button btn)
            {
                lblTask1.Content = btn.Content;
            }
        }

        
        private void Task2_Hide_Click(object sender, RoutedEventArgs e)
        {
            txtBlockTask2.Visibility = Visibility.Hidden; 
        }

        private void Task2_Show_Click(object sender, RoutedEventArgs e)
        {
            txtBlockTask2.Visibility = Visibility.Visible;
        }

       
        private void Task3_Hide_Click(object sender, RoutedEventArgs e)
        {
            txtBoxTask3.Visibility = Visibility.Collapsed; 
        }

        private void Task3_Show_Click(object sender, RoutedEventArgs e)
        {
            txtBoxTask3.Visibility = Visibility.Visible;
        }

        private void Task3_Clear_Click(object sender, RoutedEventArgs e)
        {
            txtBoxTask3.Clear();
        }

       
        private void Task4_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                btn.Visibility = Visibility.Hidden;
                CheckWinCondition();
            }
        }

        private void CheckWinCondition()
        {
            bool allHidden = true;
            foreach (var child in GameGrid.Children)
            {
               
                if (child is Button btn && btn.Visibility == Visibility.Visible)
                {
                    allHidden = false;
                    break;
                }
            }

            if (allHidden)
            {
                MessageBox.Show("Вітаємо! Всі кнопки сховані.");
            }
        }

        private void Task4_Restart_Click(object sender, RoutedEventArgs e)
        {
           
            foreach (var child in GameGrid.Children)
            {
                if (child is Button btn)
                {
                    btn.Visibility = Visibility.Visible;
                }
            }
        }

       
        private void Task5_Calculate_Click(object sender, RoutedEventArgs e)
        {
            string input = txtPounds.Text.Replace('.', ','); 

            if (double.TryParse(input, out double pounds))
            {
                
                double kg = pounds * 0.453592;
                lblResult.Text = $"{kg:F2} кг";
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть число.");
            }
        }
    }
}