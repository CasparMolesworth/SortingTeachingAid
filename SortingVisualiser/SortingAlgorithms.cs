using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualiser
{
    public static class SortingAlgorithms
    {
        public static void BubbleSort(int[] array, out double milliseconds)
        {
            int n = array.Length;
            milliseconds = 0;
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // Swap array[j] and array[j + 1]
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            sw.Stop();
            milliseconds = sw.ElapsedMilliseconds;
        }

        public static void InsertionSort(int[] array, out double milliseconds)
        {
            int n = array.Length;
            milliseconds = 0;
            Stopwatch sw = Stopwatch.StartNew();
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
            milliseconds = sw.ElapsedMilliseconds;
        }

        public static void MergeSort(int[] array)
        {
            if (array.Length > 1)
            {
                int mid = array.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[array.Length - mid];

                for (int i = 0; i < mid; i++)
                    left[i] = array[i];
                for (int i = mid; i < array.Length; i++)
                    right[i - mid] = array[i];

                MergeSort(left);
                MergeSort(right);

                Merge(array, left, right);
            }

        }

        private static void Merge(int[] array, int[] left, int[] right)
        {
            int i = 0, j = 0, k = 0;
            while (i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                {
                    array[k] = left[i];
                    i++;
                }
                else
                {
                    array[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < left.Length)
            {
                array[k] = left[i];
                i++;
                k++;
            }
            while (j < right.Length)
            {
                array[k] = right[j];
                j++;
                k++;
            }
        }
    }
}
