using System;
using NUnit.Framework;

namespace GcdAlgorithms.Tests
{
    [TestFixture]
    public class GcdTests
    {
        #region Euclid Algorithm

        [TestCase(0, 0)]
        [TestCase(0, 1)]
        [TestCase(15, 0)]
        [TestCase(0, -7)]
        [TestCase(-42, 0)]
        public void ValidateArguments_method_throws_exception(
            int number1, int number2)
        {
            Assert.That(
                () => Gcd.GetEuclid(number1, number2),
                Throws.TypeOf(typeof(ArgumentException)));
        }

        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = 4)]
        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-32534534, 234508, ExpectedResult = 2)]
        [TestCase(366, 54, ExpectedResult = 6)]
        [TestCase(235438, 455, ExpectedResult = 7)]
        [TestCase(624960, 49104, ExpectedResult = 4464)]
        public int GetEuclid_method_with_two_params_works_properly(
            int number1, int number2)
            => Gcd.GetEuclid(number1, number2);

        [TestCase(4356, 512, 3860, ExpectedResult = 4)]
        [TestCase(999, 33, 333, ExpectedResult = 3)]
        [TestCase(23535, 456745, 6768, ExpectedResult = 1)]
        [TestCase(666656, 66, 36, ExpectedResult = 2)]
        public int GetEuclid_method_with_three_params_works_properly(
            int number1, int number2, int number3)
            => Gcd.GetEuclid(number1, number2, number3);

        [TestCase(666656, 66, 36, 4, ExpectedResult = 2)]
        [TestCase(-55555555, 555, 555555, 5, 55, ExpectedResult = 5)]
        public int GetEuclid_method_with_several_params_works_properly(
            params int[] numbers)
            => Gcd.GetEuclid(numbers);

        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = 4)]
        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-32534534, 234508, ExpectedResult = 2)]
        [TestCase(366, 54, ExpectedResult = 6)]
        [TestCase(235438, 455, ExpectedResult = 7)]
        [TestCase(624960, 49104, ExpectedResult = 4464)]
        public int GetEuclidWithTime_method_that_returns_Int32_with_two_params_works_properly(
            int number1, int number2)
        {
            double time;

            int result = Gcd.GetEuclidWithTime(number1, number2, out time);

            Assert.That(time, Is.Not.Zero);

            return result;
        }

        [TestCase(4356, 512, 3860, ExpectedResult = 4)]
        [TestCase(999, 33, 333, ExpectedResult = 3)]
        [TestCase(23535, 456745, 6768, ExpectedResult = 1)]
        [TestCase(666656, 66, 36, ExpectedResult = 2)]
        public int GetEuclidWithTime_method_that_returns_Int32_with_three_params_works_properly(
            int number1, int number2, int number3)
        {
            double time;

            int result = Gcd.GetEuclidWithTime(number1, number2, number3, out time);

            Assert.That(time, Is.Not.Zero);

            return result;
        }

        [TestCase(666656, 66, 36, 4, ExpectedResult = 2)]
        [TestCase(-55555555, 555, 555555, 5, 55, ExpectedResult = 5)]
        public int GetEuclidWithTime_method_that_returns_Int32_with_several_params_works_properly(
            params int[] numbers)
        {
            double time;

            int result = Gcd.GetEuclidWithTime(out time, numbers);

            Assert.That(time, Is.Not.Zero);

            return result;
        }

        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = 4)]
        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-32534534, 234508, ExpectedResult = 2)]
        [TestCase(366, 54, ExpectedResult = 6)]
        [TestCase(235438, 455, ExpectedResult = 7)]
        [TestCase(624960, 49104, ExpectedResult = 4464)]
        public int GetEuclidWithTime_method_that_returns_tuple_with_two_params_works_properly(
            int number1, int number2)
        {
            ValueTuple<int, double> result;

            result = Gcd.GetEuclidWithTime(number1, number2);

            Assert.That(result.Item2, Is.Not.Zero);

            return result.Item1;
        }

        [TestCase(4356, 512, 3860, ExpectedResult = 4)]
        [TestCase(999, 33, 333, ExpectedResult = 3)]
        [TestCase(23535, 456745, 6768, ExpectedResult = 1)]
        [TestCase(666656, 66, 36, ExpectedResult = 2)]
        public int GetEuclidWithTime_method_that_returns_tuple_with_three_params_works_properly(
            int number1, int number2, int number3)
        {
            ValueTuple<int, double> result;

            result = Gcd.GetEuclidWithTime(number1, number2, number3);

            Assert.That(result.Item2, Is.Not.Zero);

            return result.Item1;
        }

        [TestCase(666656, 66, 36, 4, ExpectedResult = 2)]
        [TestCase(-55555555, 555, 555555, 5, 55, ExpectedResult = 5)]
        public int GetEuclidWithTime_method_that_returns_tuple_with_several_params_works_properly(
            params int[] numbers)
        {
            ValueTuple<int, double> result;

            result = Gcd.GetEuclidWithTime(numbers);

            Assert.That(result.Item2, Is.Not.Zero);

            return result.Item1;
        }

        #endregion

        #region Stein's algorithm

        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = 4)]
        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-32534534, 234508, ExpectedResult = 2)]
        [TestCase(366, 54, ExpectedResult = 6)]
        [TestCase(235438, 455, ExpectedResult = 7)]
        [TestCase(624960, 49104, ExpectedResult = 4464)]
        public int GetStein_method_with_two_params_works_properly(
            int number1, int number2)
            => Gcd.GetStein(number1, number2);

        [TestCase(4356, 512, 3860, ExpectedResult = 4)]
        [TestCase(999, 33, 333, ExpectedResult = 3)]
        [TestCase(23535, 456745, 6768, ExpectedResult = 1)]
        [TestCase(666656, 66, 36, ExpectedResult = 2)]
        public int GetStein_method_with_three_params_works_properly(
            int number1, int number2, int number3)
            => Gcd.GetStein(number1, number2, number3);

        [TestCase(666656, 66, 36, 4, ExpectedResult = 2)]
        [TestCase(-55555555, 555, 555555, 5, 55, ExpectedResult = 5)]
        public int GetStein_method_with_several_params_works_properly(
            params int[] numbers)
            => Gcd.GetStein(numbers);

        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = 4)]
        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-32534534, 234508, ExpectedResult = 2)]
        [TestCase(366, 54, ExpectedResult = 6)]
        [TestCase(235438, 455, ExpectedResult = 7)]
        [TestCase(624960, 49104, ExpectedResult = 4464)]
        public int GetSteinWithTime_method_that_returns_Int32_with_two_params_works_properly(
            int number1, int number2)
        {
            double time;

            int result = Gcd.GetSteinWithTime(number1, number2, out time);

            Assert.That(time, Is.Not.Zero);

            return result;
        }

        [TestCase(4356, 512, 3860, ExpectedResult = 4)]
        [TestCase(999, 33, 333, ExpectedResult = 3)]
        [TestCase(23535, 456745, 6768, ExpectedResult = 1)]
        [TestCase(666656, 66, 36, ExpectedResult = 2)]
        public int GetSteinWithTime_method_that_returns_Int32_with_three_params_works_properly(
            int number1, int number2, int number3)
        {
            double time;

            int result = Gcd.GetSteinWithTime(number1, number2, number3, out time);

            Assert.That(time, Is.Not.Zero);

            return result;
        }

        [TestCase(666656, 66, 36, 4, ExpectedResult = 2)]
        [TestCase(-55555555, 555, 555555, 5, 55, ExpectedResult = 5)]
        public int GetSteinWithTime_method_that_returns_Int32_with_several_params_works_properly(
            params int[] numbers)
        {
            double time;

            int result = Gcd.GetSteinWithTime(out time, numbers);

            Assert.That(time, Is.Not.Zero);

            return result;
        }

        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-8, 4, ExpectedResult = 4)]
        [TestCase(4356, 128, ExpectedResult = 4)]
        [TestCase(-32534534, 234508, ExpectedResult = 2)]
        [TestCase(366, 54, ExpectedResult = 6)]
        [TestCase(235438, 455, ExpectedResult = 7)]
        [TestCase(624960, 49104, ExpectedResult = 4464)]
        public int GetSteinWithTime_method_that_returns_tuple_with_two_params_works_properly(
            int number1, int number2)
        {
            ValueTuple<int, double> result;

            result = Gcd.GetSteinWithTime(number1, number2);

            Assert.That(result.Item2, Is.Not.Zero);

            return result.Item1;
        }

        [TestCase(4356, 512, 3860, ExpectedResult = 4)]
        [TestCase(999, 33, 333, ExpectedResult = 3)]
        [TestCase(23535, 456745, 6768, ExpectedResult = 1)]
        [TestCase(666656, 66, 36, ExpectedResult = 2)]
        public int GetSteinWithTime_method_that_returns_tuple_with_three_params_works_properly(
            int number1, int number2, int number3)
        {
            ValueTuple<int, double> result;

            result = Gcd.GetSteinWithTime(number1, number2, number3);

            Assert.That(result.Item2, Is.Not.Zero);

            return result.Item1;
        }

        [TestCase(666656, 66, 36, 4, ExpectedResult = 2)]
        [TestCase(-55555555, 555, 555555, 5, 55, ExpectedResult = 5)]
        public int GetSteinWithTime_method_that_returns_tuple_with_several_params_works_properly(
            params int[] numbers)
        {
            ValueTuple<int, double> result;

            result = Gcd.GetSteinWithTime(numbers);

            Assert.That(result.Item2, Is.Not.Zero);

            return result.Item1;
        }

        #endregion
    }
}
