using Lb7.Models;
using System.Windows;

namespace Lb7.Views
{
    public partial class CandidateWindow : Window
    {
        private Candidate _candidate;

        public CandidateWindow(Candidate candidate)
        {
            InitializeComponent();
            _candidate = candidate;
            DataContext = _candidate;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            // Проста валідація
            if (string.IsNullOrWhiteSpace(_candidate.FullName))
            {
                MessageBox.Show("Введіть ПІБ.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (_candidate.BirthYear < 1950 || _candidate.BirthYear > 2010)
            {
                MessageBox.Show("Некоректний рік.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DialogResult = true;
            Close();
        }
    }
}