using System;
using System.Collections.Generic;
using System.Globalization;

namespace ChangeCalculator.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter the Amount: ");
            var amount = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the Product Price: ");
            var price = Convert.ToDouble(Console.ReadLine());

            var calculator = new ChangeCalculator();
            calculator.CalculateChange(amount, price);
            
            DisplayData(calculator.GetChange());
        }

        private static void DisplayData(Dictionary<double, int> data)
        {
            Console.WriteLine("Your change is:");
            foreach (var item in data)
            {
                Console.WriteLine($"{item.Value} X {(item.Key < 1 ? (item.Key * 100) + "p" : item.Key.ToString("C0", CultureInfo.CurrentCulture))}");
            }
        }
    }
}
