using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace ChallengeReview
{
    internal class extents
    {
        private static void Main(string[] args)
        {
            
            var extentsFileLines = File.ReadAllLines("extents.txt");

            var extentsFileSize = extentsFileLines.Length ; 

            var aLeftRange = new uint[extentsFileSize];
            var aRightRange = new uint[extentsFileSize];

            for (var i = 0; i <= extentsFileSize-1; i++ )
            {
                aLeftRange[i] = uint.Parse(extentsFileLines[i].Split(' ')[0]);
                aRightRange[i] = uint.Parse(extentsFileLines[i].Split(' ')[1]);               
            }

	    //Be aware that if Numbers is too big, yo could get a memory exceptions and need to read by batch	
            var aNumbers = File.ReadAllLines("numbers.txt").Select(sNumbers => uint.Parse(sNumbers)).ToArray();
             
            var results = ElaborateResults(aLeftRange, aRightRange, aNumbers);
            var filename = "resultsSDB_" + +DateTime.Now.Hour + "_" + DateTime.Now.Minute + ".txt";
            System.IO.File.WriteAllLines(filename, results.ConvertAll(x => x.ToString()).ToArray());

        }

         
        private static List<uint> ElaborateResults(uint[] aLeft, uint[] aRight, uint[] aNumbers)
        {
            var results = new List<uint>();
            var numbersDictionary = new Dictionary<uint, uint>();

            //NB the maximum number of Numbers is several billions LongLength is safer
            var numbSize = aNumbers.LongLength - 1;

            for (long i = 0; i <= numbSize; i++)
            {
                uint currentNumber = aNumbers[i];

                if (!numbersDictionary.ContainsKey(currentNumber))
                {
                    var occurrences = GetNumberOfOccurrencesInTheRange(currentNumber, aLeft, aRight);

                    results.Add(occurrences);
                    numbersDictionary.Add(currentNumber, occurrences);
                }
                else
                {
                    results.Add(numbersDictionary[currentNumber]);
                }
            }
            return results;
        }

        private static uint GetNumberOfOccurrencesInTheRange(uint currentNumber, uint[] aLeft, uint[] aRight)
        {
            uint occurrences = 0;

            //NB the maximum number of range is 50 milion so length is OK
            var rangesize = aLeft.Length - 1;
            for (int y = 0; y <= rangesize; y++)
            {
                if ((currentNumber >= aLeft[y]) && (currentNumber <= aRight[y])) occurrences++;
            }
            return occurrences;
        }
    }
}