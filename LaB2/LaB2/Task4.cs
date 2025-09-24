using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LaB2
{
    class Task4
    {
        private static string filePath = "translate.txt";

        public static void Run()
        {
            
            var dict = new Dictionary<string, List<string>>();

            
            if (File.Exists(filePath))
            {
                foreach (var line in File.ReadAllLines(filePath))
                {
                    var parts = line.Split('→');
                    if (parts.Length == 2)
                    {
                        string word = parts[0].Trim();
                        string[] translations = parts[1].Split(',').Select(t => t.Trim()).ToArray();

                        if (!dict.ContainsKey(word))
                            dict[word] = new List<string>();

                        dict[word].AddRange(translations);
                    }
                }
            }

            while (true)
            {
                
                Console.WriteLine("\nМеню словника:");
                Console.WriteLine("1 - Додати слово");
                Console.WriteLine("2 - Пошук перекладу");
                Console.WriteLine("3 - Вивести всі слова");
                Console.WriteLine("0 - Вихід");

                Console.Write("Ваш вибір: ");
                string choice = Console.ReadLine() ?? "0";

                if (choice == "0") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Введіть слово: ");
                        string word = Console.ReadLine() ?? "";
                        Console.Write("Введіть переклад: ");
                        string translation = Console.ReadLine() ?? "";
                        if (!dict.ContainsKey(word)) dict[word] = new List<string>();
                        dict[word].Add(translation);

                       
                        SaveDictionary(dict);
                        Console.WriteLine("Додано і збережено!");
                        break;

                    case "2":
                        Console.Write("Введіть слово для пошуку: ");
                        string search = Console.ReadLine() ?? "";
                        if (dict.ContainsKey(search))
                            Console.WriteLine($"Переклади: {string.Join(", ", dict[search])}");
                        else
                            Console.WriteLine("Слово не знайдено");
                        break;

                    case "3":
                        Console.WriteLine("Словник:");
                        foreach (var pair in dict)
                            Console.WriteLine($"{pair.Key} → {string.Join(", ", pair.Value)}");
                        break;
                }
            }
        }

        private static void SaveDictionary(Dictionary<string, List<string>> dict)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var pair in dict)
                {
                    writer.WriteLine($"{pair.Key} → {string.Join(", ", pair.Value)}");
                }
            }
        }
    }
}
