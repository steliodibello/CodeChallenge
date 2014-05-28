using EqualExperts.Core.Interfaces;
using Moq;
using NUnit.Framework;

namespace EqualExperts.Core.Test
{
    public class NumberProcessorTest
    {
        private Mock<IMathUtilities> _mockMath;
        private NumberProcessor _numberProcessor;

        [SetUp]
        public void Instrument()
        {
            _numberProcessor = new NumberProcessor(new MathUtilities());
            _mockMath = new Mock<IMathUtilities>();
        }

        [Test]
        [TestCase(1, "1")]
        [TestCase(2, "2")]
        [TestCase(8, "8")]
         public void TestNumbersNonMultiplicableBy3Or5OrContains3(int number, string expectedString)
        {
            Assert.AreEqual(_numberProcessor.ProcessNumber(number), expectedString);
        }

        [Test]
        [TestCase(6, "fizz")]
        [TestCase(9, "fizz")]
        [TestCase(27, "fizz")]
        public void TestNumbersMultiplicableOnlyBy3AndNotContains3(int number, string expectedString)
        {
            Assert.AreEqual(_numberProcessor.ProcessNumber(number), expectedString);
        }

        [Test]
        [TestCase(13, Constants.ContainsNumberThree)]
        [TestCase(3, Constants.ContainsNumberThree)]
         public void TestNumbersContains3(int number, string expectedString)
        {
            Assert.AreEqual(_numberProcessor.ProcessNumber(number), expectedString);
        }

        [Test]
        [TestCase(35, Constants.ContainsNumberThree)]
         public void TestNumbersMultiplicableOnlyBy5AndContains3(int number, string expectedString)
        {
            Assert.AreEqual(_numberProcessor.ProcessNumber(number), expectedString);
        }

        [Test]
        [TestCase(5, "buzz")]
        [TestCase(20, "buzz")]
        public void TestNumbersMultiplicableOnlyBy5AndNotContains3(int number, string expectedString)
        {
            Assert.AreEqual(_numberProcessor.ProcessNumber(number), expectedString);
        }

        [Test]
        [TestCase(15, "fizzbuzz")]
        [TestCase(60, "fizzbuzz")]
        //NB Zero is considered a multiple of all the integers...
        [TestCase(0, "fizzbuzz")]
        public void TestNumbersMultiplicableBy3And5AndNotContains3(int number, string expectedString)
        {
            Assert.AreEqual(_numberProcessor.ProcessNumber(number), expectedString);
        }

        [Test]
        public void CheckThatIamDividingTwiceWhenIProcessANumberThatDoesNotContain3()
        {
            _numberProcessor = new NumberProcessor(_mockMath.Object);
            string result = _numberProcessor.ProcessNumber(2);

            _mockMath.Verify(x => x.IsDividibleByThree(2), Times.Once);
            _mockMath.Verify(x => x.IsDividibleByFive(2), Times.Once);
            Assert.AreEqual(result, "2", "Cannot return the right string when is not divisible");
        }

        [Test]
        public void CheckThatIamNotDividingTwiceWhenIProcessANumberThatContain3()
        {
            _mockMath.Setup(x => x.ContainsNumberThree(It.IsAny<int>())).Returns(true);

            _numberProcessor = new NumberProcessor(_mockMath.Object);
            string result = _numberProcessor.ProcessNumber(2);

            _mockMath.Verify(x => x.IsDividibleByThree(2), Times.Never);
            _mockMath.Verify(x => x.IsDividibleByFive(2), Times.Never);
            Assert.AreEqual(result, Constants.ContainsNumberThree, "Cannot return the right string when a number contains 3");
        }


        [Test]
        public void CheckThatIamReturningRightStringWhenDividingBy3()
        {
            _mockMath.Setup(x => x.IsDividibleByThree(It.IsAny<int>())).Returns(true);

            _numberProcessor = new NumberProcessor(_mockMath.Object);

            string result = _numberProcessor.ProcessNumber(2);
            Assert.AreEqual(result, Constants.DivisibleBy3Prefix, "Cannot return the right string when dividing by 3");
        }

        [Test]
        public void CheckThatIamReturningRightStringWhenDividingBy5()
        {
            _mockMath.Setup(x => x.IsDividibleByFive(It.IsAny<int>())).Returns(true);

            _numberProcessor = new NumberProcessor(_mockMath.Object);

            string result = _numberProcessor.ProcessNumber(2);
            Assert.AreEqual(result, Constants.DivisibleBy5Prefix, "Cannot return the right string when dividing by 5");
        }

        [Test]
        public void CheckThatIamReturningRightStringWhenDividingBy3And5AndDoesNotContain3()
        {
            _mockMath.Setup(x => x.IsDividibleByFive(It.IsAny<int>())).Returns(true);
            _mockMath.Setup(x => x.IsDividibleByThree(It.IsAny<int>())).Returns(true);

            _numberProcessor = new NumberProcessor(_mockMath.Object);

            string result = _numberProcessor.ProcessNumber(2);
            Assert.AreEqual(result, Constants.DivisibleBy3Prefix + Constants.DivisibleBy5Prefix,
                "Cannot return the right string when dividing by 3 and 5");
        }

        [Test]
        public void CheckThatIamReturningRightStringWhenIsDivisibilefor3And5AndDoesNotContain3()
        {
            _mockMath.Setup(x => x.IsDividibleByFive(It.IsAny<int>())).Returns(true);
            _mockMath.Setup(x => x.IsDividibleByThree(It.IsAny<int>())).Returns(true);

            _numberProcessor = new NumberProcessor(_mockMath.Object);

            string result = _numberProcessor.ProcessNumber(2);
            Assert.AreEqual(result, Constants.DivisibleBy3Prefix + Constants.DivisibleBy5Prefix,
                "Cannot return the right string when dividing by 3 and 5");
        }
    }
}