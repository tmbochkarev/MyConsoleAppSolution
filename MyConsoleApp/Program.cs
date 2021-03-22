using System;
using System.Globalization;

namespace MyConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Input your number: ");

            var rubles = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            var dollar = rubles / 74.25m;
            var euro = rubles / 88.72m;

            dollar = Math.Round(dollar, 2);
            euro = Math.Round(euro, 2);

            Console.WriteLine($"Dollar is {dollar} for {rubles} rubles. Euro is {euro} for {rubles} rubles");
        }
    }
}