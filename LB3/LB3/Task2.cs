using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LB3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Phone
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public double Price { get; set; }
        public DateTime ReleaseDate { get; set; }
    }

    class Task2
    {
        public static void Run()
        {
            List<Phone> phones = new List<Phone>
        {
            new Phone { Name = "iPhone 13", Manufacturer = "Apple", Price = 999, ReleaseDate = new DateTime(2021, 9, 20) },
            new Phone { Name = "iPhone 14", Manufacturer = "Apple", Price = 1200, ReleaseDate = new DateTime(2022, 9, 25) },
            new Phone { Name = "Galaxy S22", Manufacturer = "Samsung", Price = 850, ReleaseDate = new DateTime(2022, 2, 10) },
            new Phone { Name = "Pixel 7", Manufacturer = "Google", Price = 700, ReleaseDate = new DateTime(2022, 10, 1) },
            new Phone { Name = "Xperia Z", Manufacturer = "Sony", Price = 400, ReleaseDate = new DateTime(2019, 3, 5) },
            new Phone { Name = "Redmi 10", Manufacturer = "Xiaomi", Price = 350, ReleaseDate = new DateTime(2021, 5, 15) }
        };

            Console.WriteLine($"Кількість телефонів: {phones.Count}");
            Console.WriteLine($"Телефонів з ціною > 100: {phones.Count(p => p.Price > 100)}");
            Console.WriteLine($"Телефонів з ціною 400–700: {phones.Count(p => p.Price >= 400 && p.Price <= 700)}");
            Console.WriteLine($"Apple телефонів: {phones.Count(p => p.Manufacturer == "Apple")}");
            Console.WriteLine($"Мінімальна ціна: {phones.Min(p => p.Price)}");
            Console.WriteLine($"Максимальна ціна: {phones.Max(p => p.Price)}");

            var oldest = phones.OrderBy(p => p.ReleaseDate).First();
            var newest = phones.OrderByDescending(p => p.ReleaseDate).First();

            Console.WriteLine($"\nНайстаріший: {oldest.Name}, {oldest.ReleaseDate.ToShortDateString()}");
            Console.WriteLine($"Найновіший: {newest.Name}, {newest.ReleaseDate.ToShortDateString()}");
            Console.WriteLine($"Середня ціна: {phones.Average(p => p.Price):F2}");

            Console.WriteLine("\n5 найдорожчих телефонів:");
            foreach (var p in phones.OrderByDescending(p => p.Price).Take(5))
                Console.WriteLine($"{p.Name} - {p.Price}");

            Console.WriteLine("\n5 найдешевших телефонів:");
            foreach (var p in phones.OrderBy(p => p.Price).Take(5))
                Console.WriteLine($"{p.Name} - {p.Price}");

            Console.WriteLine("\n3 найстаріші телефони:");
            foreach (var p in phones.OrderBy(p => p.ReleaseDate).Take(3))
                Console.WriteLine($"{p.Name} - {p.ReleaseDate.ToShortDateString()}");

            Console.WriteLine("\n3 найновіші телефони:");
            foreach (var p in phones.OrderByDescending(p => p.ReleaseDate).Take(3))
                Console.WriteLine($"{p.Name} - {p.ReleaseDate.ToShortDateString()}");

            Console.WriteLine("\nКількість телефонів кожного виробника:");
            foreach (var g in phones.GroupBy(p => p.Manufacturer))
                Console.WriteLine($"{g.Key} - {g.Count()}");

            Console.WriteLine("\nКількість моделей телефонів:");
            foreach (var g in phones.GroupBy(p => p.Name))
                Console.WriteLine($"{g.Key} - {g.Count()}");

            Console.WriteLine("\nСтатистика телефонів за роками:");
            foreach (var g in phones.GroupBy(p => p.ReleaseDate.Year))
                Console.WriteLine($"{g.Key} - {g.Count()}");
        }
    }

}
