using System.Linq;
using EqualExperts.Models;
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
        [TestCase(1, 20, "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz")]
        [TestCase(3, 5, "lucky 4 buzz")]
        [TestCase(13, 17, "lucky 14 fizzbuzz 16 17")]
        [TestCase(-2, 4, "-2 -1 fizzbuzz 1 2 lucky 4")]
        [TestCase(3, 3, "lucky")]
       public void TestRange(int firstValue, int secondValue, string expectedString)
       {
           Assert.AreEqual(_rangeProcessor.Process(firstValue, secondValue).ResultingString, expectedString); 
       }

        [Test]
        [TestCase(1, 20, "1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz",2,4,3,1,10)]
        [TestCase(3, 5, "lucky 4 buzz",1,0,1,0,1)]
        [TestCase(13, 17, "lucky 14 fizzbuzz 16 17",1,0,0,1,3)]
        [TestCase(-2, 4, "-2 -1 fizzbuzz 1 2 lucky 4",1,0,0,1,5)]
        [TestCase(3, 3, "lucky",1,0,0,0,0)]
        public void TestRangeAndReport(int firstValue, int secondValue, string expectedString,int lucky,int fizz,int buzz,int fizzbuzz,int remainingInt)
        {
            var result =_rangeProcessor.Process(firstValue, secondValue);

            Assert.AreEqual(result.ResultingString, expectedString);
            Assert.AreEqual(result.CountFizz, fizz);
            Assert.AreEqual(result.CountBuzz, buzz);
            Assert.AreEqual(result.CountFizzBuzz, fizzbuzz);
            Assert.AreEqual(result.CountLucky, lucky);
            Assert.AreEqual(result.CountInteger, remainingInt);
    
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

        [Test]
        [TestCase(1,1,1,1,10)]
        public void CheckRemainingInteger(int fizz,int buzz,int lucky,int fizzbuzz,int count)
        {
          var result=  _rangeProcessor.GetIntegerWords(
                new ProcessorResult {CountBuzz = buzz, CountFizz = fizz, CountFizzBuzz = fizzbuzz, CountLucky = lucky},
                count);
            var expRes = count - fizz - buzz - fizzbuzz - lucky;
            Assert.AreEqual(result,expRes);
        }

        [Test]
        [TestCase("1 2 lucky 4 buzz fizz 7 8 fizz buzz 11 fizz lucky 14 fizzbuzz 16 17 fizz 19 buzz")]
        public void TestReport(string result)
        {
            var list = result.Split(' ').ToList();
            var report = _rangeProcessor.GenerateOutput(list);

            Assert.AreEqual(report.CountInteger,10);
            Assert.AreEqual(report.CountLucky, 2);
            Assert.AreEqual(report.CountFizz, 4);
            Assert.AreEqual(report.CountBuzz, 3);
            Assert.AreEqual(report.CountFizzBuzz, 1);



        }
    }
}
