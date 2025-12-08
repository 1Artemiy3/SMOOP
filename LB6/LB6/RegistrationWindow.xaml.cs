using Lb6.Models;
using System.Windows;

namespace Lb6
{
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                string.IsNullOrWhiteSpace(txtLastName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Заповніть всі текстові поля.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (!int.TryParse(txtAge.Text, out int age) || age < 18 || age > 100)
            {
                MessageBox.Show("Вік має бути числом від 18 до 100.", "Помилка валідації", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (txtRegPassword.Password != txtConfirmPassword.Password)
            {
                MessageBox.Show("Паролі не співпадають.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (chkAgree.IsChecked == false)
            {
                MessageBox.Show("Ви повинні погодитись з правилами.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

             
            User newUser = new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Email = txtEmail.Text,
                Age = age,
                Password = txtRegPassword.Password
            };

            MessageBox.Show($"Користувач {newUser.GetInfo()} успішно зареєстрований!", "Успіх");

            // Повернення до логіну
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }
    }
}