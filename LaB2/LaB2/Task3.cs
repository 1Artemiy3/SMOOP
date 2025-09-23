using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaB2
{
    public class PrintJob
    {
        public string User { get; set; }
        public string Document { get; set; }
        public int Priority { get; set; } // 1 - високий, 2 - середній, 3 - низький
        public DateTime Time { get; set; } = DateTime.Now;

        public override string ToString()
        {
            return $"{Document} (користувач: {User}, пріоритет: {Priority}, час: {Time})";
        }
    }

    class Task3
    {
        public static void Run()
        {
            var queue = new List<PrintJob>();
            var history = new List<PrintJob>();

            queue.Add(new PrintJob { User = "Олег", Document = "Звіт.docx", Priority = 2 });
            queue.Add(new PrintJob { User = "Анна", Document = "Презентація.pptx", Priority = 1 });
            queue.Add(new PrintJob { User = "Ігор", Document = "Книга.pdf", Priority = 3 });

            queue.Sort((a, b) => a.Priority.CompareTo(b.Priority));

            Console.WriteLine("Початок друку:");
            while (queue.Count > 0)
            {
                var job = queue[0];
                queue.RemoveAt(0);
                history.Add(job);
                Console.WriteLine($"Друк: {job}");
            }

            Console.WriteLine("\nІсторія друку:");
            foreach (var j in history) Console.WriteLine(j);
        }
    }
}
