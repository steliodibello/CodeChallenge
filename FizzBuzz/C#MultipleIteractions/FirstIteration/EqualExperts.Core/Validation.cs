namespace EqualExperts.Core
{
    public class Validation : IValidation
    {
        public bool ValidateInput(int firstNumber, int secondNumber)
        {
            return firstNumber <= secondNumber;
        }
    }
}
