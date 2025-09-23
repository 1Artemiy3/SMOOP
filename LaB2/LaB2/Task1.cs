using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB2
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int TotalCopies { get; set; }
        public int TakenCopies { get; set; }

        public Book(string author, string title, int year, int total, int taken)
        {
            Author = author;
            Title = title;
            Year = year;
            TotalCopies = total;
            TakenCopies = taken;
        }

        public bool AvailableForReading()
        {
            return (TotalCopies - TakenCopies) > 1;
        }

        public override string ToString()
        {
            return $"{Title} — {Author}, {Year} | В наявності: {TotalCopies - TakenCopies}";
        }
    }

    class Task1
    {
        public static void Run()
        {
            List<Book> library = new List<Book>
        {
            new Book("Стівен Кінг", "Зелена миля", 1996, 10, 8),
            new Book("Джордж Мартін", "Гра престолів", 1996, 7, 6),
            new Book("Дж. К. Ролінг", "Гаррі Поттер і філософський камінь", 1997, 15, 13),
            new Book("Дж. К. Ролінг", "Гаррі Поттер і таємна кімната", 1998, 12, 10)
        };

          
            var bookToEdit = library.FirstOrDefault(b => b.Title.Contains("Гра престолів"));
            if (bookToEdit != null) bookToEdit.TakenCopies = 5;

            Console.Write("Введіть пошукову послідовність у назві книги: ");
            string search = Console.ReadLine() ?? "";

            var result = library
                .Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase) && b.AvailableForReading())
                .OrderByDescending(b => b.TotalCopies - b.TakenCopies)
                .ToList();

            Console.WriteLine("\nДоступні книги:");
            foreach (var b in result) Console.WriteLine(b);

            File.WriteAllLines("result_books.txt", result.Select(b => b.ToString()));
            Console.WriteLine("\nРезультат збережено у result_books.txt");
        }
    }
}
