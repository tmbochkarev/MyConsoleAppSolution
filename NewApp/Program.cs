using System;
using System.Linq;

namespace NewApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Input your number here: ");

            var getNumber = Convert.ToInt64(Console.ReadLine());
            // todo: sum - возможно, есть более легковеснное решение
            var getDigitsOfTheNumber = getNumber.ToString().Sum(c => c - '0');
            var getReminderOfTheNumber = getDigitsOfTheNumber % 3;
            if (getDigitsOfTheNumber % 3 == 0)



            {
                Console.WriteLine($"Number {getNumber} divides on 3 without the reminder");
            }
            else
            {
                Console.WriteLine($"Number {getNumber} divides on 3 with the reminder");
                Console.WriteLine($"Reminder of the number {getNumber} is {getReminderOfTheNumber}");
            }
        }
    }
}