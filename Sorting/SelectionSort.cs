using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Swap(int[] array, int i, int j) {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    
    static void SelectionSort(int[] array) {
            var mIndex=0;
            for(int i=0; i<array.Length - 1; i++) {
                mIndex = i;
                for(int j=i+1; j<array.Length; j++) {
                    if (array[mIndex] > array[j]) {
                        mIndex = j;
                    }
                }
                
                if (mIndex != i) {
                    Swap(array, i, mIndex);
                }
            }
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int[] array = new int[] {2, 6, 8, 2, 1, 5, 3, 4, 9, 0};
        SelectionSort(array);
        for(int i=0; i<array.Length - 1; i++) {
            Console.WriteLine(array[i] + ",");
        }
    }
}
