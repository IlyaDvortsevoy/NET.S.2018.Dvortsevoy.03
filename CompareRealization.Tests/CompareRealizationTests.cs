using System;
using CompareRealization;
using NUnit.Framework;

namespace CompareRealization.Tests
{
    [TestFixture]
    public class CompareRealizationTests
    {
        [TestCase(3)]
        [TestCase(0)]
        [TestCase(5)]
        [TestCase(9)]
        public void FilterDigitByDivision_executes_successfully_on_big_array(int digit)
        {
            int[] array = CreateBigArray();

            (int[] numbers, TimeSpan time) result = 
                AlgorithmVariants.FilterDigitByDivision(digit, array);

            TestContext.WriteLine($"Execution time: {result.time.Milliseconds}");

            Assert.IsTrue(IsExpectedArray(digit, result.numbers));
        }

        [TestCase(1)]
        [TestCase(7)]
        [TestCase(0)]
        [TestCase(2)]
        public void FilterDigitByArrays_executes_successfully_on_big_array(int digit)
        {
            int[] array = CreateBigArray();

            (int[] numbers, TimeSpan time) result =
                AlgorithmVariants.FilterDigitByArrays(digit, array);

            TestContext.WriteLine($"Execution time: {result.time.Milliseconds}");

            Assert.IsTrue(IsExpectedArray(digit, result.numbers));
        }

        [TestCase(-1, 2, 0, 1)]
        [TestCase(Int32.MinValue, 1, 1, 3)]
        [TestCase(-3, 77, 89, 12)]
        [TestCase(-100, 34, 3, 88)]
        [TestCase(-99999, 56, 7, 80)]
        public void ValidateDigit_throws_exception_when_number_is_out_of_the_range(
            int number,
            params int[] array)
        {
            Assert.That(
                () => AlgorithmVariants.FilterDigitByDivision(number, array),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(
                () => AlgorithmVariants.FilterDigitByArrays(number, array),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [TestCase(-1, null)]
        [TestCase(Int32.MinValue, null)]
        [TestCase(-3, null)]
        [TestCase(-100, null)]
        [TestCase(-99999, null)]
        public void ValidateArray_throws_exception_if_null_argument_was_passed(
            int number,
            params int[] array)
        {
            Assert.That(
                () => AlgorithmVariants.FilterDigitByDivision(number, array),
                Throws.TypeOf<ArgumentOutOfRangeException>());

            Assert.That(
                () => AlgorithmVariants.FilterDigitByArrays(number, array),
                Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        #region Private Methods
        private static int[] CreateBigArray()
        {
            int[] bigArray = new int[20000000];
            var random = new Random();

            for (int i = 0; i < bigArray.Length; i++)
            {
                bigArray[i] = random.Next(int.MinValue, int.MaxValue);
            }

            return bigArray;
        }

        private static bool IsExpectedArray(int digit, int[] array)
        {
            foreach (var number in array)
            {
                bool expected = false;
                int temp = number;

                if (temp < 0)
                {
                    temp *= -1;
                }

                while (temp > 0)
                {
                    if (temp % 10 == digit)
                    {
                        expected = true;
                        break;
                    }

                    temp /= 10;
                }

                if (expected == false)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion
    }
}