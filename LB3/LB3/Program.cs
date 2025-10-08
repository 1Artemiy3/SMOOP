using LB3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {

            Console.WriteLine("\nЛабораторна робота №3. Меню завдань:");
            Console.WriteLine("1 - Фірма ");
            Console.WriteLine("2 - Телефон");
            Console.WriteLine("3 - Підприємство");
            Console.WriteLine("0 - Вихід");

            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine() ?? "0";

            switch (choice)
            {
                case "1": Task1.Run(); break;
                case "2": Task2.Run(); break;
                case "3": Task3.Run(); break;
                case "0": return;
                default: Console.WriteLine("Невірний вибір!"); break;
            }
        }
    }
}
