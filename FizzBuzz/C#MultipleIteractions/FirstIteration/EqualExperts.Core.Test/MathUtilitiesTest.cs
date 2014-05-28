using NUnit.Framework;

namespace EqualExperts.Core.Test
{
    [TestFixture]
   public class MathUtilitiesTest
    {
        private MathUtilities _mathUtilities;
        [SetUp]
        public void Setup()
        {
            _mathUtilities= new MathUtilities();
        }

        [Test]
        [TestCase(9,3,true)]
        [TestCase(9, 2, false)]
        [TestCase(8, 2, true)]
        public void TestIsDivisible(int input,int divisibleBy,bool result)
        {
            Assert.AreEqual(_mathUtilities.IsDivisible(input,divisibleBy),result);
        }

        [Test]
        [TestCase(9,  true)]
        [TestCase(2,  false)]
        [TestCase(27,  true)]
        [TestCase(-3, true)]
        public void TestIsDivisibleBy3(int input, bool result)
        {
            Assert.AreEqual(_mathUtilities.IsDividibleByThree(input), result);
        }

        [Test]
        [TestCase(5, true)]
        [TestCase(7, false)]
        [TestCase(35, true)]
        [TestCase(45, true)]
        [TestCase(15, true)]
        [TestCase(-10, true)]
        public void TestIsDivisibleBy5(int input, bool result)
        {
            Assert.AreEqual(_mathUtilities.IsDividibleByFive(input), result);
        }


    }
}
