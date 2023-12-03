using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Adventofcode23
{
    internal class Day1
    {
        public static void Main()
        {
            //Part1();
            Part2();
        }

        static void Part1()
        {
            string? input = Console.ReadLine();
            int sum = 0;
            while (input != "")
            {
                int[] values = new int[2];
                int result;
                for (int i = 0; i < input.Length; i++)
                {
                    if (int.TryParse(input[i].ToString(), out result))
                    {
                        values[0] = result;
                        break;
                    }
                }
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(input[i].ToString(), out result))
                    {
                        values[1] = result;
                        break;
                    }
                }
                sum += (values[0] * 10) + values[1];

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }


        // Include numbers: one, two, three, four, five, six, seven, eight, nine
        static void Part2()
        {
            string[] numberWords = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            string? input = Console.ReadLine();
            int sum = 0;
            while (input != "")
            {
                int[] values = new int[2];
                int result;
                for (int i = 0; i < input.Length; i++)
                {
                    // Regular numbers
                    if (int.TryParse(input[i].ToString(), out result))
                    {
                        values[0] = result;
                        break;
                    }

                    // Word numbers
                    for (int j = 1; j <= 9; j++)
                    {
                        if (TryFindWord(input, i, numberWords[j - 1]))
                        {
                            values[0] = j;
                            i = input.Length; // break outer loop
                            break;
                        }
                    }
                }
                for (int i = input.Length - 1; i >= 0; i--)
                {
                    // Regular numbers
                    if (int.TryParse(input[i].ToString(), out result))
                    {
                        values[1] = result;
                        break;
                    }

                    // Word numbers
                    for (int j = 1; j <= 9; j++)
                    {
                        string numWord = numberWords[j - 1];
                        if (TryFindWord(input, i - (numWord.Length-1), numWord))
                        {
                            values[1] = j;
                            i = -1; // break outer loop
                            break;
                        }
                    }
                }
                sum += (values[0] * 10) + values[1];

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }

        static bool TryFindWord(string input, int index, string word) {
            if (index < 0) return false;
            if (index + word.Length > input.Length) return false;

            string substr = input.Substring(index, word.Length);
            return substr == word;
        }
    }
}
