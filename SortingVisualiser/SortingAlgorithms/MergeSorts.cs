using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualiser.SortingAlgorithms
{
    class MergeSorts
    {
        // Normal Merge Sort
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
