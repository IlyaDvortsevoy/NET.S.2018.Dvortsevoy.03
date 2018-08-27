using System;
using System.Diagnostics;

namespace GcdAlgorithms
{
    /// <summary>
    /// Contains algorithms for the greatest common divisor calculation
    /// </summary>
    public static class Gcd
    {
        #region Public API

        #region Euclidean Algorithm

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <returns> The greatest common divisor of two numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetEuclid(int number1, int number2)
        {
            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            ValidateArguments(number1, number2);

            int temp1 = number1;
            int temp2 = number2;
            int min;
            int remainder;

            while (true)
            {
                min = temp1 > temp2 ? temp2 : temp1;

                remainder = temp1 > temp2 ?
                    temp1 % temp2 : temp2 % temp1;

                if (remainder == 0)
                {
                    return min;
                }

                if (min == 0 || remainder == min)
                {
                    return remainder;
                }

                temp1 = remainder;
                temp2 = min;
            }
        }

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="number3"> The third number for calculation </param>
        /// <returns> The greatest common divisor of three numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetEuclid(int number1, int number2, int number3) =>
            GetGcd(GetEuclid, number1, number2, number3);

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// </summary>
        /// <param name="numbers"> The sequence of numbers for calculation </param>
        /// <returns> The greatest common divisor of the sequence of numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetEuclid(params int[] numbers) =>
            GetGcd(GetEuclid, numbers);

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="milliseconds"> The time of execution </param>
        /// <returns> The greatest common divisor of two numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetEuclidWithTime(
            int number1,
            int number2,
            out double milliseconds)
            => GetGcdWithTime(
                () => GetEuclid(number1, number2),
                out milliseconds);

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="number3"> The third number for calculation </param>
        /// <param name="milliseconds"> The time of execution </param>
        /// <returns> The greatest common divisor of three numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetEuclidWithTime(
            int number1,
            int number2,
            int number3,
            out double milliseconds)
            => GetGcdWithTime(
                () => GetEuclid(number1, number2, number3),
                out milliseconds);

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="milliseconds"> The time of execution </param>
        /// <param name="numbers"> The sequence of numbers for calculation </param>
        /// <returns> The greatest common divisor of the sequence of numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetEuclidWithTime(
            out double milliseconds,
            params int[] numbers)
            => GetGcdWithTime(
                () => GetEuclid(numbers),
                out milliseconds);

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <returns> The tuple consisting of the greatest common divisor of two numbers
        /// and the execution time </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static (int, double) GetEuclidWithTime(
            int number1,
            int number2)
            => GetGcdWithTime(() => GetEuclid(number1, number2));

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="number3"> The third number for calculation </param>
        /// <returns> The tuple consisting of the greatest common divisor of three numbers
        /// and the execution time </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static (int, double) GetEuclidWithTime(
            int number1,
            int number2,
            int number3)
            => GetGcdWithTime(() => GetEuclid(number1, number2, number3));

        /// <summary>
        /// Returns the greatest common divisor calculated using Euclidean algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="numbers"> The sequence of numbers for calculation </param>
        /// <returns> The tuple consisting of the greatest common divisor of the sequence of numbers
        /// and the execution time </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static (int, double) GetEuclidWithTime(params int[] numbers)
            => GetGcdWithTime(() => GetEuclid(numbers));
        #endregion

        #region Stein's algorithm

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <returns> The greatest common divisor of two numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetStein(int number1, int number2)
        {
            ValidateArguments(number1, number2);

            number1 = Math.Abs(number1);
            number2 = Math.Abs(number2);

            ValidateArguments(number1, number2);

            if (number1 == 0)
            {
                return number2;
            }

            if (number2 == 0 || number1 == number2)
            {
                return number1;
            }

            bool number1IsEven = (number1 & 1) == 0;
            bool number2IsEven = (number2 & 1) == 0;

            if (number1IsEven && number2IsEven)
            {
                return GetStein(number1 >> 1, number2 >> 1) << 1;
            }
            else if (number1IsEven && !number2IsEven)
            {
                return GetStein(number1 >> 1, number2);
            }
            else if (number2IsEven)
            {
                return GetStein(number1, number2 >> 1);
            }
            else if (number1 > number2)
            {
                return GetStein((number1 - number2) >> 1, number2);
            }
            else
            {
                return GetStein(number1, (number2 - number1) >> 1);
            }
        }

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="number3"> The third number for calculation </param>
        /// <returns> The greatest common divisor of three numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetStein(int number1, int number2, int number3) =>
            GetGcd(GetStein, number1, number2, number3);

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// </summary>
        /// <param name="numbers"> The sequence of numbers for calculation </param>
        /// <returns> The greatest common divisor of the sequence of numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetStein(params int[] numbers) =>
            GetGcd(GetStein, numbers);

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="milliseconds"> The time of execution </param>
        /// <returns> The greatest common divisor of two numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetSteinWithTime(
            int number1,
            int number2,
            out double milliseconds)
             => GetGcdWithTime(
                () => GetStein(number1, number2),
                out milliseconds);

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="number3"> The third number for calculation </param>
        /// <param name="milliseconds"> The time of execution </param>
        /// <returns> The greatest common divisor of three numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetSteinWithTime(
            int number1,
            int number2,
            int number3,
            out double milliseconds)
             => GetGcdWithTime(
                () => GetStein(number1, number2, number3),
                out milliseconds);

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="milliseconds"> The time of execution </param>
        /// <param name="numbers"> The sequence of numbers for calculation </param>
        /// <returns> The greatest common divisor of the sequence of numbers </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static int GetSteinWithTime(
            out double milliseconds,
            params int[] numbers)
             => GetGcdWithTime(
                () => GetStein(numbers),
                out milliseconds);

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <returns> The tuple consisting of the greatest common divisor of two numbers
        /// and the execution time </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static (int, double) GetSteinWithTime(
            int number1,
            int number2)
             => GetGcdWithTime(
                () => GetStein(number1, number2));

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="number1"> The first number for calculation </param>
        /// <param name="number2"> The second number for calculation </param>
        /// <param name="number3"> The third number for calculation </param>
        /// <returns> The tuple consisting of the greatest common divisor of three numbers
        /// and the execution time </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static (int, double) GetSteinWithTime(
            int number1,
            int number2,
            int number3)
             => GetGcdWithTime(
                () => GetStein(number1, number2, number3));

        /// <summary>
        /// Returns the greatest common divisor calculated using Stein's algorithm
        /// and the time of execution
        /// </summary>
        /// <param name="numbers"> The sequence of numbers for calculation </param>
        /// <returns> The tuple consisting of the greatest common divisor of the sequence of numbers
        /// and the execution time </returns>
        /// <exception cref="ArgumentException"> Thrown when one of arguments is zero </exception>
        public static (int, double) GetSteinWithTime(
            params int[] numbers)
             => GetGcdWithTime(
                () => GetStein(numbers));

        #endregion

        #endregion

        #region Private Methods
        private static int GetGcd(Func<int, int, int> gcd, int number1, int number2, int number3)
        {
            int temp = gcd(number1, number2);

            return gcd(temp, number3);
        }

        private static int GetGcd(Func<int, int, int> gcd, params int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException(
                    "The parameter can't be null",
                    nameof(numbers));
            }

            if (numbers.Length < 2)
            {
                throw new ArgumentException(
                    "There should be at least two arguments",
                    nameof(numbers));
            }

            int temp = gcd(numbers[0], numbers[1]);

            for (int i = 2; i < numbers.Length; i++)
            {
                temp = gcd(temp, numbers[i]);
            }

            return temp;
        }

        private static int GetGcdWithTime(Func<int> gcd, out double milliseconds)
        {
            var timer = new Stopwatch();
            timer.Start();

            int result = gcd.Invoke();

            timer.Stop();
            milliseconds = timer.Elapsed.TotalSeconds;

            return result;
        }

        private static (int, double) GetGcdWithTime(Func<int> gcd)
        {
            var timer = new Stopwatch();
            timer.Start();

            int result = gcd.Invoke();

            timer.Stop();
            double milliseconds = timer.Elapsed.TotalSeconds;

            return (result, milliseconds);
        }

        private static void ValidateArguments(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                throw new ArgumentException(
                    "The parameter can't be zero");
            }
        }
        #endregion
    }
}
