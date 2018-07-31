using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CompareRealization
{
    /// <summary>
    /// Contains two realizations of the filtering array algorithm
    /// </summary>
    public static class AlgorithmVariants
    {
        /// <summary>
        /// Filters input array and returns array containing only numbers with given digit
        /// </summary>
        /// <param name="array"> Input array of integer numbers </param>
        /// <param name="digit"> The given integer digit for filtering </param>
        /// <returns> Filtered array of integer numbers </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Occurs if the given digit is out of the range from 0 to 9 </exception>
        public static (int[] result, TimeSpan time) FilterDigitByDivision(int digit, params int[] array)
        {
            var watch = new Stopwatch();
            watch.Start();

            ValidateDigit(digit);
            ValidateArray(array);

            var list = new List<int>();

            foreach (var number in array)
            {
                int temp = number;

                if (temp < 0)
                {
                    temp *= -1;
                }

                while (temp > 0)
                {
                    if (temp % 10 == digit)
                    {
                        list.Add(number);
                        break;
                    }

                    temp /= 10;
                }
            }

            watch.Stop();

            return (list.ToArray(), watch.Elapsed);
        }

        /// <summary>
        /// Filters input array and returns array containing only numbers with given digit
        /// </summary>
        /// <param name="array"> Input array of integer numbers </param>
        /// <param name="digit"> The given integer digit for filtering </param>
        /// <returns> Filtered array of integer numbers </returns>
        /// <exception cref="ArgumentOutOfRangeException"> Occurs if the given digit is out of the range from 0 to 9 </exception>
        public static (int[] result, TimeSpan time) FilterDigitByArrays(int digit, params int[] array)
        {
            var watch = new Stopwatch();
            watch.Start();

            ValidateDigit(digit);
            ValidateArray(array);

            var list = new List<int>();
            string fromDigit = digit.ToString();

            foreach (var number in array)
            {
                string temp = number.ToString();
                if (temp.Contains(fromDigit))
                {
                    list.Add(number);
                }
            }

            watch.Stop();

            return (list.ToArray(), watch.Elapsed);
        }

        #region Private Methods
        /// <summary>
        /// Validates the array built from input integer parameters
        /// </summary>
        /// <param name="array"> The built array of the integer numbers </param>
        /// <exception cref="ArgumentNullException"> Occurs if null argument was passed </exception>
        private static void ValidateArray(int[] array)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }
        }

        /// <summary>
        /// Validates that a value of the integer digit is in the range from 0 to 9
        /// </summary>
        /// <param name="digit"> The integer digit to validate </param>
        /// <exception cref="ArgumentOutOfRangeException"> Occurs if the integer digit is out of the range </exception>
        private static void ValidateDigit(int digit)
        {
            if (digit < 0 || digit > 9)
            {
                throw new ArgumentOutOfRangeException(nameof(digit));
            }
        }
        #endregion
    }
}