using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Sorting
{
    // Added Type constraint to let methods use Icomparable methods.
    public class SortingBase<T> where T : IComparable<T>
    {
        public void Display(T[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Debug.WriteLine(array[i]);
                Console.WriteLine(array[i]);
            }

        }

        public void Swap(T[] array, int i, int j)
        {
            T temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public bool LessOrEqual(T left, T right)
        {
            return left.CompareTo(right) <= 0;
        }
    }
}
