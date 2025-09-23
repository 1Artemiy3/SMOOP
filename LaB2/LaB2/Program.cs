using LaB2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            
            Console.WriteLine("\nЛабораторна робота №2. Меню завдань:");
            Console.WriteLine("1 - Книги ");
            Console.WriteLine("2 - Аналіз текстових файлів");
            Console.WriteLine("3 - Черга друку принтера");
            Console.WriteLine("4 - Словники");
            Console.WriteLine("0 - Вихід");

            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine() ?? "0";

            switch (choice)
            {
                case "1": Task1.Run(); break;
                case "2": Task2.Run(); break;
                case "3": Task3.Run(); break;
                case "4": Task4.Run(); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір!"); break;
            }
        }
    }
}
