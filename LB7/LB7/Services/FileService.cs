using Lb7.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Lb7.Services
{
    public class FileService
    {
        private const string PATH = "candidates.txt";

        // Метод завантаження даних
        public ObservableCollection<Candidate> LoadData()
        {
            var list = new ObservableCollection<Candidate>();

            if (!File.Exists(PATH))
                return list;

            try
            {
                var lines = File.ReadAllLines(PATH);
                foreach (var line in lines)
                {
                    var parts = line.Split(';');
                    if (parts.Length >= 7)
                    {
                        list.Add(new Candidate
                        {
                            FullName = parts[0],
                            BirthYear = int.Parse(parts[1]),
                            Education = parts[2],
                            Languages = parts[3],
                            ComputerSkills = bool.Parse(parts[4]),
                            Experience = int.Parse(parts[5]),
                            HasRecommendation = bool.Parse(parts[6])
                        });
                    }
                }
            }
            catch (Exception)
            {
                // Якщо файл пошкоджено, повертаємо порожній список або обробляємо помилку
            }

            return list;
        }

        // Метод збереження даних
        public void SaveData(ObservableCollection<Candidate> candidates)
        {
            var lines = candidates.Select(c =>
                $"{c.FullName};{c.BirthYear};{c.Education};{c.Languages};{c.ComputerSkills};{c.Experience};{c.HasRecommendation}"
            );

            File.WriteAllLines(PATH, lines);
        }
    }
}