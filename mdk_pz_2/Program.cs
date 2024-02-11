using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mdk_pz_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] quotes1 = { 32, 29, 35, 33, 37, 30, 31 };
            int[] quotes2 = { 32, 35, 34, 32, 30, 31 };
            int[] quotes3 = { 32, 34, 35, 35, 32, 29 };

            int result1 = FindLongestSaw(quotes1);
            int result2 = FindLongestSaw(quotes2);
            int result3 = FindLongestSaw(quotes3);

            Console.WriteLine($"Котировки 1: {result1} сегментов");
            Console.WriteLine($"Котировки 2: {result2} сегментов");
            Console.WriteLine($"Котировки 3: {result3} сегментов");

        }

        static int FindLongestSaw(int[] arr)
        {
            if (arr.Length < 2)
            {
                return 0;
            }

            int currentSawLength = 1;
            int maxSawLength = 0;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                if ((arr[i] > arr[i - 1] && arr[i] > arr[i + 1]) || (arr[i] < arr[i - 1] && arr[i] < arr[i + 1]))
                {
                    currentSawLength++;
                }
                else
                {
                    if (currentSawLength > 1)
                    {
                        maxSawLength = Math.Max(maxSawLength, currentSawLength);
                    }
                    currentSawLength = 1;
                }
            }

            return maxSawLength;
        }
    }
    
}
