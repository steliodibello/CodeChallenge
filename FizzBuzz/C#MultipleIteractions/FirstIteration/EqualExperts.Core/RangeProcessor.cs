using System.Collections.Generic;

namespace EqualExperts.Core
{
    public class RangeProcessor
    {
        private readonly INumberProcessor _numberProcessor;

        public RangeProcessor(INumberProcessor numberProcessor)
        {
            _numberProcessor = numberProcessor;
        }

        public string Process(int firstNumber, int secondNumber)
        {
            var elements = new List<string>();
            for (int i = firstNumber; i <= secondNumber; i++)
            {
                elements.Add(_numberProcessor.ProcessNumber(i));
            }
            return string.Join(" " ,elements);
        }
    }
}
