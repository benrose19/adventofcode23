using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventofcode23
{
    internal class Day4
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
            SortedSet<int> list = new();
            while (input != "")
            {
                list.Clear();
                string[] card = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int i = 2;
                while (card[i] != "|")
                {
                    list.Add(int.Parse(card[i]));
                    i++;
                }

                int cumulValue = 0;
                for (i++; i < card.Length; i++)
                {
                    int currNum = int.Parse(card[i]);
                    if (list.Contains(currNum))
                    {
                        if (cumulValue == 0) cumulValue = 1;
                        else cumulValue *= 2;
                    }
                }
                sum += cumulValue;

                input = Console.ReadLine();
            }

            Console.WriteLine(sum);
        }

        static void Part2()
        {
            string? input = Console.ReadLine();
            List<int> cardInfo = new();
            int cardNum = 1;
            while (input != "")
            {
                SortedSet<int> list = new();
                string[] card = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (cardInfo.Count < cardNum) cardInfo.Add(1);

                int i = 2;
                while (card[i] != "|")
                {
                    list.Add(int.Parse(card[i]));
                    i++;
                }

                int iter = cardNum;
                for (i++; i < card.Length; i++)
                {
                    int currNum = int.Parse(card[i]);
                    if (list.Contains(currNum))
                    {
                        if (cardInfo.Count < iter + 1) cardInfo.Add(1);
                        cardInfo[iter] += cardInfo[cardNum-1];
                        iter++;
                    }
                }

                cardNum++;
                input = Console.ReadLine();
            }

            int sum = 0;
            foreach (int i in cardInfo)
            {
                sum += i;
            }

            Console.WriteLine(sum);
        }
    }
}
