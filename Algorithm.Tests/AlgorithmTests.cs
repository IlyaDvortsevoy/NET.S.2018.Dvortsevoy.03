using System;
using System.Diagnostics;
using NUnit.Framework;

namespace Algorithm.Tests
{
    [TestFixture]
    public class AlgorithmTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double FindNthRoot_Returns_ExpectedResult(
            double number,
            int degree,
            double precision)
        {
            double result = Algorithms.FindNthRoot(
                number, degree, precision);

            return result;
        }

        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(1, ExpectedResult = -1)]
        [TestCase(156173890, ExpectedResult = 156173908)]
        [TestCase(11133217, ExpectedResult = 11133271)]
        [TestCase(2047483647, ExpectedResult = 2047483674)]
        [TestCase(77655432, ExpectedResult = -1)]
        public int FindNextBiggerNumber_Returns_ExpectedResult(int number)
        {
            (int number, TimeSpan time) result = 
                Algorithms.FindNextBiggerNumber(number);

            TestContext.WriteLine($"Execution time: {result.time.Milliseconds}");

            return result.number;
        }

        [TestCase(-1)]
        [TestCase(Int32.MinValue)]
        [TestCase(-7)]
        [TestCase(-231)]
        [TestCase(-1346)]
        public void ValidateNumber_throws_exception_when_number_is_negative(int number)
        {
            Assert.That(
                () => Algorithms.FindNextBiggerNumber(number),
                Throws.TypeOf<ArgumentException>());
        }
    }
}