using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SamuraiApp.Domain;

namespace ConsoleApp
{
    internal class Program
    {
        // instance
        private static SamuraiContext context = new SamuraiContext();

        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai { Name = "Sampson" };
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
