using System.Text;
using EqualExperts.Core.Interfaces;

namespace EqualExperts.Core
{
    public class NumberProcessor : INumberProcessor
    {
        private readonly IMathUtilities _mathUtilities;

        public NumberProcessor(IMathUtilities mathUtilities)
        {
            _mathUtilities = mathUtilities;
        }

        public string ProcessNumber(int input)
        {
            var sb = new StringBuilder();

            if (_mathUtilities.IsDividibleByThree(input))
            {
                sb.Append(Constants.DivisibleBy3Prefix);
            }

            if (_mathUtilities.IsDividibleByFive(input))
            {
                sb.Append(Constants.DivisibleBy5Prefix);
            }

            var result = sb.ToString();
            if (string.IsNullOrWhiteSpace(result))
            {
                return input.ToString();
            }

            return result;
        }
    }
}