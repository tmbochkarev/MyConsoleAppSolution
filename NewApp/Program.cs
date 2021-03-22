using System;
using System.Linq;

namespace NewApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your number here: ");

            long getNumber = Convert.ToInt64(Console.ReadLine());
            
            byte getDigitsOfTheNumber = Convert.ToByte(getNumber.ToString().Sum(c => c - '0'));

            byte getReminderOfTheNumber = Convert.ToByte(getDigitsOfTheNumber % 3);

            

            if ( getDigitsOfTheNumber % 3 == 0 )
            {
                Console.WriteLine($"Number { getNumber } divides on 3 without the reminder");
            }
            else
            {
                Console.WriteLine($"Number { getNumber } divides on 3 with the reminder");
                Console.WriteLine($"Reminder of the number { getNumber } is { getReminderOfTheNumber }");
            }
        }
    }
}
