using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingVisualiser.SortingAlgorithms
{
    public abstract class Algorithm
    {
        protected int comparisons;
        protected int swaps;

        public Algorithm()
        {
            comparisons = 0;
            swaps = 0;
        }
    }
}
