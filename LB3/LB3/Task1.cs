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

    public class Firm
    {
        public string Name { get; set; }
        public DateTime FoundationDate { get; set; }
        public string BusinessProfile { get; set; }
        public string Director { get; set; }
        public int EmployeesCount { get; set; }
        public string Address { get; set; }
    }

    class Task1
    {
        public static void Run()
        {
            List<Firm> firms = new List<Firm>
        {
            new Firm { Name = "WhiteFood", FoundationDate = DateTime.Now.AddYears(-3), BusinessProfile = "Marketing", Director = "John White", EmployeesCount = 150, Address = "London" },
            new Firm { Name = "TechVision", FoundationDate = DateTime.Now.AddYears(-1), BusinessProfile = "IT", Director = "Anna Black", EmployeesCount = 200, Address = "Kyiv" },
            new Firm { Name = "GreenFood", FoundationDate = DateTime.Now.AddYears(-5), BusinessProfile = "Food", Director = "Steve Jobs", EmployeesCount = 120, Address = "London" },
            new Firm { Name = "MarketPlus", FoundationDate = DateTime.Now.AddMonths(-160), BusinessProfile = "Marketing", Director = "Olga White", EmployeesCount = 90, Address = "Paris" }
        };

            Console.WriteLine("Усі фірми:");
            foreach (var f in firms) Console.WriteLine($"{f.Name} — {f.BusinessProfile}, {f.EmployeesCount} працівників, директор: {f.Director}");

            Console.WriteLine("\nФірми з назвою Food:");
            foreach (var f in firms.Where(f => f.Name.Contains("Food"))) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми з профілем Marketing:");
            foreach (var f in firms.Where(f => f.BusinessProfile == "Marketing")) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми з профілем Marketing або IT:");
            foreach (var f in firms.Where(f => f.BusinessProfile == "Marketing" || f.BusinessProfile == "IT")) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми з кількістю співробітників > 100:");
            foreach (var f in firms.Where(f => f.EmployeesCount > 100)) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми з кількістю співробітників від 100 до 300:");
            foreach (var f in firms.Where(f => f.EmployeesCount >= 100 && f.EmployeesCount <= 300)) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми у Лондоні:");
            foreach (var f in firms.Where(f => f.Address == "London")) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми з директором White:");
            foreach (var f in firms.Where(f => f.Director.Contains("White"))) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми, засновані понад 2 роки тому:");
            foreach (var f in firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 365 * 2)) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми, засновані понад 150 днів тому:");
            foreach (var f in firms.Where(f => (DateTime.Now - f.FoundationDate).TotalDays > 150)) Console.WriteLine(f.Name);

            Console.WriteLine("\nФірми з директором Black і назвою, що містить White:");
            foreach (var f in firms.Where(f => f.Director.Contains("Black") && f.Name.Contains("White"))) Console.WriteLine(f.Name);
        }
    }

}
