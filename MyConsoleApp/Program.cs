using System;
using System.Globalization;


namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            Console.WriteLine("Input your number: ");

            decimal rouble = Convert.ToDecimal(Console.ReadLine());
            
            
            decimal dollar = rouble / (decimal)74.25;

            decimal euro = rouble / (decimal)88.72;

            dollar = Math.Round(dollar, 2);

            euro = Math.Round(euro, 2);

            Console.WriteLine($"Dollar is {dollar} for {rouble} roubles. Euro is {euro} for {rouble} roubles");

        }
    }
}
