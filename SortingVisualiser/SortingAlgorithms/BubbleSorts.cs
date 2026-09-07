using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualiser.SortingAlgorithms
{
    public static class BubbleSorts
    {

        private static Stopwatch sw = new Stopwatch();

        // Timed Bubble Sort
        public static void BubbleSort(int[] array, out double ticks)
        {
            int n = array.Length;
            ticks = 0;
            sw.Start();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            sw.Reset();
        }

        // Animated Bubble Sort
        public static void AnimatedBubbleSort(int[] array)
        {
            int n = array.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
    }
}
