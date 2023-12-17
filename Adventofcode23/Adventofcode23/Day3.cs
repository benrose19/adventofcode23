using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode23
{
    internal class Day3
    {
        public static void Main()
        {
            //Part1();
            Part2();
        }

        static void Part1()
        {
            string? line1 = Console.ReadLine();
            string? line2 = Console.ReadLine();
            int sum = 0;
            while (line2 != "")
            {
                for (int i = 0; line2 != null && i < line1?.Length; i++)
                {
                    char ch1 = line1[i];
                    char ch2 = line2[i];

                    if (ch1 != '.' && !char.IsDigit(ch1))
                    {
                        int findInt;
                        string newString;
                        if (TryParseMultiDigit(line1, i - 1, out findInt, out newString))
                        {
                            line1 = newString;
                            sum += findInt;
                        }
                        if (TryParseMultiDigit(line1, i + 1, out findInt, out newString))
                        {
                            line1 = newString;
                            sum += findInt;
                        }
                        if (TryParseMultiDigit(line2, i - 1, out findInt, out newString))
                        {
                            line2 = newString;
                            sum += findInt;
                        }
                        if (TryParseMultiDigit(line2, i, out findInt, out newString))
                        {
                            line2 = newString;
                            sum += findInt;
                        }
                        if (TryParseMultiDigit(line2, i + 1, out findInt, out newString))
                        {
                            line2 = newString;
                            sum += findInt;
                        }
                    }
                    if (ch2 != '.' && !char.IsDigit(ch2))
                    {
                        int findInt;
                        string newString;
                        if (TryParseMultiDigit(line1, i - 1, out findInt, out newString))
                        {
                            line1 = newString;
                            sum += findInt;
                        }
                        if (TryParseMultiDigit(line1, i, out findInt, out newString))
                        {
                            line1 = newString;
                            sum += findInt;
                        }
                        if (TryParseMultiDigit(line1, i + 1, out findInt, out newString))
                        {
                            line1 = newString;
                            sum += findInt;
                        }
                    }
                }

                line1 = line2;
                line2 = Console.ReadLine();
            }
            for (int i = 0; i < line1?.Length; i++)
            {
                char ch1 = line1[i];

                if (ch1 != '.' && !char.IsDigit(ch1))
                {
                    int findInt;
                    string newString;
                    if (TryParseMultiDigit(line1, i - 1, out findInt, out newString))
                    {
                        line1 = newString;
                        sum += findInt;
                    }
                    if (TryParseMultiDigit(line1, i + 1, out findInt, out newString))
                    {
                        line1 = newString;
                        sum += findInt;
                    }
                }
            }

            Console.WriteLine(sum);
        }

        static void Part2()
        {
            string? line1 = Console.ReadLine();
            string? line2 = Console.ReadLine();
            string? line3 = Console.ReadLine();

            int sum = 0;
            for (int i = 0; line2 != null && i < line1?.Length; i++)
            {
                if (line1[i] == '*')
                {
                    string? temp = null;
                    sum += CheckGear(ref temp, ref line1, ref line2, i);
                }
            }
            
            while (line2 != "")
            {
                for (int i = 0; line2 != null && i < line1?.Length; i++)
                {
                    if (line2[i] == '*')
                    {
                        sum += CheckGear(ref line1, ref line2, ref line3, i);
                    }
                }

                line1 = line2;
                line2 = line3;
                line3 = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        static bool TryParseMultiDigit(string parseInput, int checkIndex, out int parseResult, out string newString)
        {
            parseResult = -1;
            newString = parseInput;

            int cumulNum = 0;
            if (!char.IsDigit(parseInput[checkIndex])) return false;
            while (checkIndex > 0 && char.IsDigit(parseInput[checkIndex-1])) checkIndex--;
            int start = checkIndex;

            int parseDig;
            while (checkIndex < parseInput.Length && int.TryParse(parseInput[checkIndex].ToString(), out parseDig))
            {
                cumulNum = cumulNum * 10 + parseDig;
                newString = newString.Substring(0, checkIndex) + "." + newString.Substring(checkIndex + 1);
                checkIndex++;
            }

            parseResult = cumulNum;
            return true;
        }

        /// <summary>
        /// Look for numbers around the given gear on line2 and return the gear's ratio number
        /// </summary>
        /// <param name="line1"></param>
        /// <param name="line2"></param>
        /// <param name="line3"></param>
        /// <param name="gearIndex"></param>
        /// <returns></returns>
        static int CheckGear(ref string? line1, ref string line2, ref string? line3, int gearIndex)
        {
            int findInt;
            string newString;
            int gearRatio = 1;
            bool secondFound = false;

            string?[] lines = { line1, line2, line3 };
            for (int i = 0; i < 3; i++)
            {
                if (lines[i] == null) continue;

                for (int j = gearIndex-1; j <= gearIndex+1; j++)
                {
                    if (TryParseMultiDigit(lines[i], j, out findInt, out newString))
                    {
                        lines[i] = newString;
                        secondFound = gearRatio != 1;
                        gearRatio *= findInt;
                    }
                }
                
            }

            if (!secondFound) return 0;
            return gearRatio;
        }
    }
}
