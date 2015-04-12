using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Swap(int[] array, int i, int j) {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
    
    /// <summary>
    /// Best case: n-1 compares, 0 exchanges,
    /// Partially sorted array: linear 
    /// Worst case: 1/2 n sqr compares, 1/2 nsqr exchanges (Even slower than selection sort)
    /// </summary>
    static void InsertionSort(int[] array) {
        for(int i = 1; i < array.Length; i++) {
            for(int j = i; j > 0; j--) {
                if (array[j - 1] > array[j]) {
                    Swap(array, j - 1, j);
                } else {
                    break;
                }
            }
        }
    }
    
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int[] array = new int[] {2, 6, 8, 2, 1, 5, 3, 4, 9, 0};
        InsertionSort(array);
        for(int i = 0; i < array.Length - 1; i++) {
            Console.WriteLine(array[i] + ",");
        }
    }
}
