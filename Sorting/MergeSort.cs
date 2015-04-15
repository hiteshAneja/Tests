using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sorting
{
    public class MergeSort<T> : SortingBase<T> where T : IComparable<T>
    {
        private void InsertionSort(T[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j - 1].CompareTo(array[j]) > 0)
                    {
                        Swap(array, j - 1, j);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }

        public void Merge(T[] array, T[] left, T[] right)
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
                else if (left[j].CompareTo(right[k]) < 0) array[i] = left[j++];
                else array[i] = right[k++];
            }
        }

        public void Sort(T[] array)
        {
            if (array.Length > 1)
            {
                // Split the left array into two halves.
                int mid = array.Length / 2;
                T[] left = new T[mid];
                T[] right = new T[array.Length - mid];

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

        /// <summary>
        /// There is always a cost involve in recursion and merge sort 
        /// does not prove to be faster when it comes to working with small arrays,
        /// so for item less than ~4, we here by use insertion sort.
        /// </summary>
        public void OptimumSort(T[] array)
        {
            if (array.Length > 1)
            {
                // Split the left array into two halves.
                int mid = array.Length / 2;

                // Create left array.
                T[] left = new T[mid];
                for (int i = 0; i < left.Length; i++)
                {
                    left[i] = array[i];
                }

                // Create right array.
                T[] right = new T[array.Length - mid];
                for (int i = 0; i < right.Length; i++)
                {
                    right[i] = array[i + mid];
                }

                // For smaller arrays than 4, use insertion sort.
                if (mid < 4)
                {
                    InsertionSort(left);
                    InsertionSort(right);
                }
                else
                {
                    // Now recursively split the left array into two halves until left and right array have only 1 element.
                    Sort(left);

                    // Now recursively split the right array into two halves until left and right array have only 1 element.
                    Sort(right);
                }

                // Merge and sort the broken arrays.
                Merge(array, left, right);
            }
        }

    }
}
