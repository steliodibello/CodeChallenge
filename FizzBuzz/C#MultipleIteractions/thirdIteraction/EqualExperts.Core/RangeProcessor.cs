using System.Collections.Generic;
using System.Linq;
using EqualExperts.Models;

namespace EqualExperts.Core
{
    public class RangeProcessor
    {
        private readonly INumberProcessor _numberProcessor;

        public RangeProcessor(INumberProcessor numberProcessor)
        {
            _numberProcessor = numberProcessor;
        }

        public ProcessorResult Process(int firstNumber, int secondNumber)
        {
            var elements = new List<string>();
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                elements.Add(_numberProcessor.ProcessNumber(i));
            }
            return GenerateOutput(elements);
        }

        public ProcessorResult GenerateOutput(List<string> input)
        {
            var result = new ProcessorResult();
            result.ResultingString = string.Join(" ", input);
            result.CountLucky = input.Count(ContainsNumberThree);
            result.CountFizzBuzz = input.Count(IsDivisibleBy3And5);
            result.CountFizz = input.Count(IsDivisibleOnlyBy3);
            result.CountBuzz = input.Count(IsDivisibleOnlyBy5);
            result.CountInteger = GetIntegerWords(result,input.Count);
            return result;
        }

        public int GetIntegerWords(ProcessorResult result, int totalWords)
        {
            return (totalWords - (result.CountLucky + result.CountFizzBuzz + result.CountFizz +
                                              result.CountBuzz));
        }

        public bool ContainsNumberThree(string input)
        {
            if (input == null)
            {
                return false;
            }
            return input.Contains(Constants.ContainsNumberThree);
        }
        public bool IsDivisibleOnlyBy5(string input)
        {
            if (input == null)
            {
                return false;
            }
            return input.Contains(Constants.DivisibleBy5Prefix) && !input.Contains(Constants.DivisibleBy3Prefix);
        }
        public bool IsDivisibleOnlyBy3(string input)
        {
            if (input == null)
            {
                return false;
            }
            return input.Contains(Constants.DivisibleBy3Prefix) && !input.Contains(Constants.DivisibleBy5Prefix);
        }
        public bool IsDivisibleBy3And5(string input)
        {
            if (input == null)
            {
                return false;
            }
            return input.Contains(Constants.DivisibleBy3Prefix) && input.Contains(Constants.DivisibleBy5Prefix);
        }
    }
}
