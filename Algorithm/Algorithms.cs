using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Algorithm
{
    /// <summary>
    /// Defines various types of algorithms
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        /// Сalculates root of the certain degree for the given number with the given precision
        /// </summary>
        /// <param name="number"> Given number </param>
        /// <param name="degree"> Given degree </param>
        /// <param name="precision"> Given precision </param>
        /// <returns> Square root value </returns>
        public static double FindNthRoot(double number, int degree, double precision)
        {
            int fractionalPart = precision.ToString().Length - precision.ToString().IndexOf(',') - 1;
            var previous = number / degree;
            var next = (1.0 / degree) * (((degree - 1) * previous) + (number / Math.Pow(previous, degree - 1)));

            while (Math.Abs(next - previous) > precision)
            {
                previous = next;
                next = (1.0 / degree) * (((degree - 1) * previous) + (number / Math.Pow(previous, degree - 1)));
            }

            return Math.Round(next, fractionalPart);
        }

        /// <summary>
        /// Returns the next bigger number consisted of initial digits
        /// </summary>
        /// <param name="number"> Given number </param>
        /// <returns> Next bigger number </returns>
        /// <exception cref="ArgumentException"> Throws if the given number is negative </exception>
        public static (int result, TimeSpan time) FindNextBiggerNumber(int number)
        {
            var watch = new Stopwatch();
            watch.Start();

            ValidateNumber(number);

            int[] array = NumberToArray(number);

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i - 1] > array[i])
                {
                    Swap(ref array[i - 1], ref array[i]);
                    int startPointer = 0;
                    int endPointer = i - 1;
                    while (startPointer < endPointer)
                    {
                        Swap(
                            ref array[startPointer],
                            ref array[endPointer]);
                        startPointer++;
                        endPointer--;
                    }

                    Array.Reverse(array);
                    int result = ArrayToNumber(array);
                    watch.Stop();
                    
                    return (result, watch.Elapsed);
                }
            }

            watch.Stop();

            return (-1, watch.Elapsed);
        }

        #region Private methods
        /// <summary>
        /// Throws exception if the given number is negative
        /// </summary>
        /// <param name="number"> Given number </param>
        /// <exception cref="ArgumentException"> Throws if the given number is negative </exception>
        private static void ValidateNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("The number can't be negative", nameof(number));
            }
        }

        /// <summary>
        /// Puts digit in every position of the initial number to the array of integer numbers
        /// </summary>
        /// <param name="number"> Initial number </param>
        /// <returns> Array of integer numbers containig all the digits of initial number </returns>
        private static int[] NumberToArray(int number)
        {
            var list = new List<int>();

            while (number > 0)
            {
                list.Add(number % 10);
                number /= 10;
            }

            return list.ToArray();
        }

        /// <summary>
        /// Swaps two integer numbers
        /// </summary>
        /// <param name="firstNumber"> First integer number to swap </param>
        /// <param name="secondNumber"> Second integer number to swap </param>
        private static void Swap(ref int firstNumber, ref int secondNumber)
        {
            int temp = firstNumber;
            firstNumber = secondNumber;
            secondNumber = temp;
        }

        /// <summary>
        /// Converts initial array of integer numbers to one number
        /// </summary>
        /// <param name="array"> The initial array </param>
        /// <returns></returns>
        private static int ArrayToNumber(int[] array)
        {
            int result = 0;
            int numberPosition = 1;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                result += array[i] * numberPosition;
                numberPosition *= 10;
            }

            return result;
        }
        #endregion
    }
}