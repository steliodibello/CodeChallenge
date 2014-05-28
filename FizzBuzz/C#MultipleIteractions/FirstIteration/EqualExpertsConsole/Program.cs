using System;
using EqualExperts.Core;
using FizzBuzzTest;

namespace EqualExpertsConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the first number of your range");
            int firstValue = Utilities.ReadNumericInput();
            Console.WriteLine("Please Enter the second number of your range");
            int secondValue = Utilities.ReadNumericInput();

            var validation = new Validation();
            while (!validation.ValidateInput(firstValue, secondValue))
            {
                Console.WriteLine("Please enter a value that's bigger of the first one");
                secondValue = Utilities.ReadNumericInput();
            }
            var processor = new RangeProcessor(new NumberProcessor(new MathUtilities()));
            Console.WriteLine(processor.Process(firstValue, secondValue));
            Console.ReadLine();
        }
    }
}