using System;

namespace FizzBuzzTest
{
    class Utilities
    {
        public static int ReadNumericInput()
        {
            int input;
            while (!Int32.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please Enter a valid integer");
            }
            return input;
        }
    }
}
