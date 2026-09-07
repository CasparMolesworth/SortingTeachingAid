using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomRandom;

namespace SortingVisualiser
{
    static class GeneratingArray
    {

        public static void FillArray(int[] array)
        {
            CustomRandomGenerator rand = new CustomRandomGenerator();
            int size = array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                while (true)
                {
                    int randomNumber = rand.Next(1, size + 1);
                    if (!array.Contains(randomNumber))
                    {
                        array[i] = randomNumber;
                        break;
                    }
                }
            }   
        }
    }
}
