using System;
using System.Globalization;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your number: ");

            var rouble = Convert.ToDecimal(Console.ReadLine(), CultureInfo.InvariantCulture);
            var dollar = rouble / (decimal)74.25;
            var euro = rouble / (decimal)88.72;

            dollar = Math.Round(dollar, 2);
            euro = Math.Round(euro, 2);

            Console.WriteLine($"Dollar is {dollar} for {rouble} roubles. Euro is {euro} for {rouble} roubles");
        }
    }
}
