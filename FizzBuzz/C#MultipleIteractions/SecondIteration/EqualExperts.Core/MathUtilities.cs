using EqualExperts.Core.Interfaces;

namespace EqualExperts.Core
{
    public class MathUtilities : IMathUtilities
    {
        public bool IsDividibleByThree(int input)
        {
            return  IsDivisible(input, 3);
        }

        public bool IsDividibleByFive(int input)
        {
            return IsDivisible(input, 5);
        }
       public bool IsDivisible(int input, int byValue)
       {
           return (input % byValue == 0);
       }
       public bool ContainsNumberThree(int input)
       {
           return (input.ToString().Contains("3"));
       }
    }
}
