using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB2
{
    class Task4
    {
        public static void Run()
        {
            var dict = new Dictionary<string, List<string>>();

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
                        Console.WriteLine("Додано!");
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
    }
}
