using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorting
{
    public class MergeSort : SortingBase
    {
        public void Merge(int[] array, int[] left, int[] right)
        {
            int j = 0, k = 0;

            // Loop thru the main array and fill it up with items from left and right.
            for (int i = 0; i < array.Length; i++)
            {
                // If left array is already taken, pick the remaining right array items.
                if (j >= left.Length) array[i] = right[k++];
                
                // If the right array is already taken, pick the remaining items from left array.
                else if (k >= right.Length) array[i] = left[j++];
                
                // If both the arrays have item, pick the smallest one and add to the main array.
                else if (left[j] < right[k]) array[i] = left[j++];
                else array[i] = right[k++];
            }
        }


        public void Sort(int[] array)
        {
            if (array.Length > 1)
            {
                // Split the left array into two halves.
                int mid = array.Length / 2;
                int[] left = new int[mid];
                int[] right = new int[array.Length - mid];

                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = array[i];
                }
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = array[i + mid];
                }

                // Now recursively split the left array into two halves until left and right array have only 1 element.
                Sort(left);

                // Now recursively split the right array into two halves until left and right array have only 1 element.
                Sort(right);

                // Merge and sort the broken arrays.
                Merge(array, left, right);
            }
        }

    }
}
