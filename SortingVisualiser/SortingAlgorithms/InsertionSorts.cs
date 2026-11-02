using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SortingVisualiser.SortingAlgorithms
{
    public class InsertionSorts : Algorithm
    {
        private static Stopwatch sw = new Stopwatch();

        // Timed Insertion Sort
        public static void InsertionSort(int[] array, out double ticks, out int comparisons, out int swaps)
        {
            int n = array.Length;
            ticks = 0;
            comparisons = 0;
            swaps = 0;
            sw.Start();
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                    swaps++;
                    comparisons++;
                }
                array[j + 1] = key;
                comparisons++;
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            sw.Reset();
        }
    }
}
