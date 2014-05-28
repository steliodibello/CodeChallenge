namespace EqualExperts.Core.Interfaces
{
    public interface IMathUtilities
    {
        bool IsDivisible(int input, int byValue);
        bool IsDividibleByThree(int input);
        bool IsDividibleByFive(int input);
    }
}