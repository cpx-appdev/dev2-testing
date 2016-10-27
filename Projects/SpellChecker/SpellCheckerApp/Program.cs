using System;
using Rechtschreibprüfung;

namespace SpellCheckerApp
{
    class Program
    {
        public static event Action RechtschreibprüfungStarten;

        static void Main(string[] args)
        {
            RechtschreibprüfungStarten += () =>
            {
                var fehlerhafteWörter = Interaktoren.Prüfen(Console.ReadLine());
                Console.WriteLine(fehlerhafteWörter);
                Console.ReadKey();
            };

            Console.WriteLine("Enter your text:");
            //Console.ReadKey();

            //var k = Console.ReadKey();

            //if (k.Key == ConsoleKey.Enter)
            //{
            //}


            string result = Console.ReadLine();
            if (result.Equals("y", StringComparison.OrdinalIgnoreCase) || result.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                RechtschreibprüfungStarten.Invoke();
            }
            else
            {
                Console.WriteLine("Thank you for playing.");
                Console.ReadKey();
            }
        }
    }
}
