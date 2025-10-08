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

    public class Employer
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }
        public bool HigherEducation { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public List<Employer> Employees { get; set; } = new List<Employer>();
    }

    class Task3
    {
        public static void Run()
        {
            var company = new Company { Name = "TechVision" };

            company.Employees = new List<Employer>
        {
            new Employer { Name = "Володимир", Age = 25, Position = "Worker", Salary = 800, Experience = 2, HigherEducation = true, BirthDate = new DateTime(2000,10,15) },
            new Employer { Name = "Володимир", Age = 42, Position = "Manager", Salary = 2000, Experience = 15, HigherEducation = true, BirthDate = new DateTime(1983,5,10) },
            new Employer { Name = "Олег", Age = 35, Position = "Worker", Salary = 1000, Experience = 10, HigherEducation = false, BirthDate = new DateTime(1990,10,5) },
            new Employer { Name = "Анна", Age = 30, Position = "Manager", Salary = 2500, Experience = 8, HigherEducation = true, BirthDate = new DateTime(1995,3,20) },
            new Employer { Name = "Ігор", Age = 50, Position = "President", Salary = 4000, Experience = 25, HigherEducation = true, BirthDate = new DateTime(1975,6,8) }
        };

            Console.WriteLine($"Кількість працівників: {company.Employees.Count}");
            Console.WriteLine($"Загальна зарплата: {company.Employees.Sum(e => e.Salary)}");

            var topExperienced = company.Employees.OrderByDescending(e => e.Experience).Take(10)
                .Where(e => e.HigherEducation).OrderBy(e => e.Age).FirstOrDefault();

            if (topExperienced != null)
                Console.WriteLine($"\nНаймолодший із топ-10 за стажем і з вищою освітою: {topExperienced.Name}, {topExperienced.Age} років");

            var managers = company.Employees.Where(e => e.Position == "Manager");
            Console.WriteLine($"\nНаймолодший менеджер: {managers.MinBy(e => e.Age)?.Name}");
            Console.WriteLine($"Найстарший менеджер: {managers.MaxBy(e => e.Age)?.Name}");

            Console.WriteLine("\nПрацівники, народжені у жовтні:");
            foreach (var e in company.Employees.Where(e => e.BirthDate.Month == 10))
                Console.WriteLine($"{e.Name} - {e.Position}");

            var volodymyrs = company.Employees.Where(e => e.Name == "Володимир").OrderBy(e => e.Age);
            foreach (var v in volodymyrs)
                Console.WriteLine($"Володимир: {v.Position}, {v.Age} років");

            var youngestVolodymyr = volodymyrs.FirstOrDefault();
            if (youngestVolodymyr != null)
            {
                double bonus = youngestVolodymyr.Salary / 2;
                Console.WriteLine($"\n{youngestVolodymyr.Name}, вітаємо! Премія: {bonus}");
            }
        }
    }

}
