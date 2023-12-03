using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode23
{
    internal class Day2
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
                string[] cubes = input.Split(' ', ';', ',', ':');

                int gameNum = int.Parse(cubes[1]);

                bool gameIsPossible = true;
                for (int i = 3; i < cubes.Length; i++)
                {
                    if (cubes[i].Length == 0) continue;
                    if (cubes[i] == "red")
                    {
                        int numRed = int.Parse(cubes[i-1]);
                        if (numRed > 12)
                        {
                            gameIsPossible = false;
                            break;
                        }
                    }
                    if (cubes[i] == "green")
                    {
                        int numGreen = int.Parse(cubes[i - 1]);
                        if (numGreen > 13)
                        {
                            gameIsPossible = false;
                            break;
                        }
                    }
                    if (cubes[i] == "blue")
                    {
                        int numBlue = int.Parse(cubes[i-1]);
                        if (numBlue > 14)
                        {
                            gameIsPossible = false;
                            break;
                        }
                    }

                }
                if (gameIsPossible) sum += gameNum;
                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        static void Part2()
        {
            string? input = Console.ReadLine();
            int sum = 0;
            while (input != "")
            {
                string[] cubes = input.Split(' ', ';', ',', ':');
                int maxRed = 0;
                int maxGreen = 0;
                int maxBlue = 0;
                for (int i = 3; i < cubes.Length; i++)
                {
                    if (cubes[i].Length == 0) continue;
                    if (cubes[i] == "red")
                    {
                        int numRed = int.Parse(cubes[i - 1]);
                        if (maxRed < numRed) maxRed = numRed;              
                    }
                    if (cubes[i] == "green")
                    {
                        int numGreen = int.Parse(cubes[i - 1]);
                        if (maxGreen < numGreen) maxGreen = numGreen;
                    }
                    if (cubes[i] == "blue")
                    {
                        int numBlue = int.Parse(cubes[i - 1]);
                        if (maxBlue < numBlue) maxBlue = numBlue;     
                    }

                }
                sum += maxRed * maxGreen * maxBlue;
                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }
    }
}
