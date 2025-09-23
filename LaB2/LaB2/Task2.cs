using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB2
{
    class Task2
    {
        public static void Run()
        {
            Console.Write("Введіть назву файлу для аналізу ");
            string fileName = Console.ReadLine() ?? "text.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("Файл не знайдено!");
                return;
            }

            string text = File.ReadAllText(fileName).ToLower();
            var words = text.Split(new char[] { ' ', ',', '.', '!', '?', ';', ':', '-', '\n', '\r' },
                                   StringSplitOptions.RemoveEmptyEntries);

            var stat = words.GroupBy(w => w)
                            .Select(g => new { Word = g.Key, Count = g.Count() })
                            .OrderByDescending(x => x.Count);

            Console.WriteLine("\nСтатистика використання слів:");
            foreach (var item in stat) Console.WriteLine($"{item.Word} : {item.Count}");

            File.WriteAllLines("word_stat.txt", stat.Select(x => $"{x.Word} : {x.Count}"));
            Console.WriteLine("\nРезультат збережено у word_stat.txt");
        }
    }
}

