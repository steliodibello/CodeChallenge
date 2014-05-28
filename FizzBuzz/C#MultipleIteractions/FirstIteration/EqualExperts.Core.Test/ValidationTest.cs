using NUnit.Framework;

namespace EqualExperts.Core.Test
{
    [TestFixture]
    public class ValidationTest
    {
        private Validation _validation;
        [SetUp]
        public void Instrument()
        {
            _validation = new Validation();
        }

        [Test]
        [TestCase(1, 20)]
        [TestCase(10, 53)]
        [TestCase(5, 5)]
        public void WhenFirstNumberIsSmallerTheSecondOneTheRangeIsValid(int firstValue,int secondValue)
        {
         Assert.IsTrue(_validation.ValidateInput(firstValue, secondValue));
        }

        [Test]
        [TestCase(10, 5)]
        [TestCase(52, 3)]
        public void WhenFirstNumberIsBiggerOfTheSecondOneTheRangeIsInvalid(int firstValue, int secondValue)
        {
            Assert.IsFalse(_validation.ValidateInput(firstValue, secondValue));
        }


    }
}
