using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Sorting
{
    public class SortingBase
    {
        public void Display(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
			{
                Debug.WriteLine(array[i]);
			}
        }
    }
}
