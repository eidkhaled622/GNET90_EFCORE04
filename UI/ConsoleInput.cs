using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace GNET90_EFCORE04.UI
{
    public static class ConsoleInput
    {
        public static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                if (int.TryParse(Console.ReadLine(), out var value) && value >= min && value <= max)
                    return value;

                Console.WriteLine("Invalid input, try again.");
            }
        }
        public static decimal ReadDecimal(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            while (true)
            {
                Console.Write($"{prompt}: ");
                if (decimal.TryParse(Console.ReadLine(), out var value) && value >= min && value <= max)
                    return value;

                Console.WriteLine("Invalid input, try again.");
            }
        }
        public static bool ReadString(string prompt, out string value)
        {
            Console.Write($"{prompt}: ");
            value = Console.ReadLine();

            return !string.IsNullOrWhiteSpace(value);
        }

        public static void readType<T>(List<T> titles, string prompt, out T value)
        {
            Console.WriteLine($"{prompt}: ");
            for (var i = 0; i < titles.Count(); i++)
            {
                Console.WriteLine($"{i + 1}) {titles[i]}");
            }
            value = titles[ReadInt("Choice :", 0, titles.Count()) - 1];
        }
    }
}