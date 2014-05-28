using Moq;
using NUnit.Framework;

namespace EqualExperts.Core.Test
{
    [TestFixture]
   public class RangeProcessorTest
    {
        private RangeProcessor _rangeProcessor ;

        [SetUp]
        public void Instrument()
        {
            _rangeProcessor = new RangeProcessor(new NumberProcessor(new MathUtilities()));
        }

        [Test]
        [TestCase(1, 20, "1 2 fizz 4 buzz fizz 7 8 fizz buzz 11 fizz 13 14 fizzbuzz 16 17 fizz 19 buzz")]
        [TestCase(3, 5, "fizz 4 buzz")]
        [TestCase(13, 17, "13 14 fizzbuzz 16 17")]
        [TestCase(-2, 4, "-2 -1 fizzbuzz 1 2 fizz 4")]
        [TestCase(3, 3, "fizz")]
       public void TestRange(int firstValue, int secondValue, string expectedString)
       {
           Assert.AreEqual(_rangeProcessor.Process(firstValue, secondValue), expectedString); 
       }

        [Test]
        public void CheckThatIamCallingNumberProcessorForEachNumber()
        {
            var numbProc = new Mock<INumberProcessor>();
            _rangeProcessor= new RangeProcessor(numbProc.Object);
            const int firstvalue = 1;
            const int secondvalue = 20;
            _rangeProcessor.Process(firstvalue, secondvalue);

            var count = secondvalue - firstvalue +1;
            numbProc.Verify(x => x.ProcessNumber(It.IsAny<int>()), Times.Exactly(count));

        }
    }
}
