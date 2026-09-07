using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SortingVisualiser.SortingAlgorithms
{
    public static class InsertionSorts
    {
        private static Stopwatch sw = new Stopwatch();

        // Timed Insertion Sort
        public static void InsertionSort(int[] array, out double ticks)
        {
            int n = array.Length;
            ticks = 0;
            sw.Start();
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;
                // Move elements of array[0..i-1], that are greater than key,
                // to one position ahead of their current position
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
            sw.Stop();
            ticks = sw.ElapsedTicks;
            sw.Reset();
        }

        // Animated Insertion Sort
        public static void AnimatedInsertionSort(int[] array)
        {
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = array[i];
                int j = i - 1;
                // Move elements of array[0..i-1], that are greater than key,
                // to one position ahead of their current position
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }
    }
}
