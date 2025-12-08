using System.Windows;
using System.Windows.Input;

namespace Lb6
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Будь ласка, заповніть всі поля!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            if (username == "admin" && password == "admin")
            {
                MessageBox.Show("Успішний вхід!", "Інфо", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Невірний логін або пароль.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SignUp_Click(object sender, MouseButtonEventArgs e)
        {
            // Перехід на вікно реєстрації
            RegistrationWindow regWindow = new RegistrationWindow();
            regWindow.Show();
            this.Close();
        }
    }
}