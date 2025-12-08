using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lb7.Models
{
    public class Candidate : INotifyPropertyChanged
    {
        private string _fullName;
        private int _birthYear;
        private string _education;
        private string _languages;
        private bool _computerSkills;
        private int _experience;
        private bool _hasRecommendation;

        public string FullName
        {
            get => _fullName;
            set { _fullName = value; OnPropertyChanged(); }
        }

        public int BirthYear
        {
            get => _birthYear;
            set { _birthYear = value; OnPropertyChanged(); }
        }

        public string Education
        {
            get => _education;
            set { _education = value; OnPropertyChanged(); }
        }

        public string Languages
        {
            get => _languages;
            set { _languages = value; OnPropertyChanged(); }
        }

        public bool ComputerSkills
        {
            get => _computerSkills;
            set { _computerSkills = value; OnPropertyChanged(); }
        }

        public int Experience
        {
            get => _experience;
            set { _experience = value; OnPropertyChanged(); }
        }

        public bool HasRecommendation
        {
            get => _hasRecommendation;
            set { _hasRecommendation = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}