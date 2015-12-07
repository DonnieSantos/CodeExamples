using System;

namespace Exercise1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                printOneNumber(i);
            }

            Console.ReadLine();
        }

        private static void printOneNumber(int i)
        {
            string output = string.Empty;
            bool divisibleByFive = i.isDivisibleBy(5);
            bool divisibleByThree = i.isDivisibleBy(3);

            if (divisibleByFive || divisibleByThree)
            {
                if (divisibleByThree) output += "Fizz";
                if (divisibleByFive) output += "Buzz";
            }
            else
            {
                output += i.ToString();
            }

            Console.WriteLine(output);
        }
    }
}