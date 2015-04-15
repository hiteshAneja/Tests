using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorting
{
    public class QuickSort<T> : SortingBase<T> where T: IComparable<T>
    {
        private int Partition(T[] array, int start, int end)
        {
            var pIndex = start;
            var pivot = array[end];
            for (int i = start; i < end; i++)
            {
                if (LessOrEqual(array[i], pivot))
                {
                    Swap(array, i, pIndex);
                    pIndex++;
                }
            }
            Swap(array, pIndex, end);

            return pIndex;
        }

        public void Sort(T[] array, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            int pIndex = Partition(array, start, end);
            Sort(array, start, pIndex - 1);
            Sort(array, pIndex + 1, end);
        }

    }
}
