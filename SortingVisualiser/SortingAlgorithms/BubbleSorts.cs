using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualiser.SortingAlgorithms
{
    public class BubbleSorts : Algorithm
    {
        private static Stopwatch sw = new Stopwatch();
        public BubbleSorts()
        {
            comparisons = 0;
            swaps = 0;
        }

        // Timed Bubble Sort
        public static void BubbleSort(int[] array, out double ticks, out int comparisons, out int swaps)
        {
            int n = array.Length;
            ticks = 0;
            comparisons = 0;
            swaps = 0;
            sw.Start();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        comparisons++;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swaps++;
                    }
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            sw.Reset();
        }
    }
}
