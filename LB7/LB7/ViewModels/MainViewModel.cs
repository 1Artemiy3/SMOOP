using Lb7.Infrastructure;
using Lb7.Models;
using Lb7.Services; 
using Lb7.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace Lb7.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly FileService _fileService; // Поле для сервісу

        public ObservableCollection<Candidate> Candidates { get; set; }
        private ICollectionView _candidatesView;

        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                OnPropertyChanged("FilterText");
                _candidatesView.Refresh();
            }
        }

        private Candidate _selectedCandidate;
        public Candidate SelectedCandidate
        {
            get => _selectedCandidate;
            set { _selectedCandidate = value; OnPropertyChanged("SelectedCandidate"); }
        }

        public RelayCommand AddCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand DeleteCommand { get; }

        public MainViewModel()
        {
            _fileService = new FileService();

            
            Candidates = _fileService.LoadData();

            
            if (Candidates.Count == 0)
            {
                
            }

            _candidatesView = CollectionViewSource.GetDefaultView(Candidates);
            _candidatesView.Filter = o =>
            {
                if (string.IsNullOrEmpty(FilterText)) return true;
                var c = (Candidate)o;
                return (c.FullName?.ToLower().Contains(FilterText.ToLower())) ?? false;
            };

            AddCommand = new RelayCommand(_ => AddCandidate());
            EditCommand = new RelayCommand(_ => EditCandidate(), _ => SelectedCandidate != null);
            DeleteCommand = new RelayCommand(_ => DeleteCandidate(), _ => SelectedCandidate != null);
        }

        private void AddCandidate()
        {
            var newCandidate = new Candidate { BirthYear = 2000, Education = "Вища" };
            var window = new CandidateWindow(newCandidate);
            if (window.ShowDialog() == true)
            {
                Candidates.Add(newCandidate);
                _fileService.SaveData(Candidates); 
            }
        }

        private void EditCandidate()
        {
            var window = new CandidateWindow(SelectedCandidate);
            if (window.ShowDialog() == true)
            {
                _fileService.SaveData(Candidates); 
            }
        }

        private void DeleteCandidate()
        {
            if (SelectedCandidate != null)
            {
                Candidates.Remove(SelectedCandidate);
                _fileService.SaveData(Candidates); 
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}