using System;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;

[Serializable]
public class Book
{
    public string Author { get; set; }
    public string Title { get; set; }
    public int Year { get; set; }
    public int TotalCopies { get; set; }
    public int TakenCopies { get; set; }

    public Book() { } // конструктор без параметрів для XML/JSON

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
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        // створюємо масив книг
        List<Book> library = new List<Book>
        {
            new Book("Стівен Кінг", "Зелена миля", 1996, 10, 8),
            new Book("Джордж Мартін", "Гра престолів", 1996, 7, 6),
            new Book("Дж. К. Ролінг", "Гаррі Поттер і філософський камінь", 1997, 15, 13),
            new Book("Дж. К. Ролінг", "Гаррі Поттер і таємна кімната", 1998, 12, 10)
        };

        Console.Write("Введіть пошукову послідовність у назві книги: ");
        string search = Console.ReadLine() ?? "";

        var result = library
            .Where(b => b.Title.Contains(search, StringComparison.OrdinalIgnoreCase) && b.AvailableForReading())
            .OrderByDescending(b => b.TotalCopies - b.TakenCopies);

        Console.WriteLine("\n Доступні книги:");
        foreach (var b in result)
        {
            Console.WriteLine($"{b.Title} — {b.Author}, {b.Year} | В наявності: {b.TotalCopies - b.TakenCopies}");
        }

        // --- JSON серіалізація ---
        string json = JsonSerializer.Serialize(library, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("library.json", json);
        Console.WriteLine("\nДані збережено у library.json");

        // --- XML серіалізація ---
        XmlSerializer xml = new XmlSerializer(typeof(List<Book>));
        using (FileStream fs = new FileStream("library.xml", FileMode.Create))
        {
            xml.Serialize(fs, library);
        }
        Console.WriteLine("Дані збережено у library.xml");

       
    }
}
