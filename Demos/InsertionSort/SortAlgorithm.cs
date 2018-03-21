using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    public class SortAlgorithm
    {
        public static void InsertSort<T, C>(T[] array, C comparer)
            where C : IComparer<T>
        {
            for (int i = 1; i <= array.Length - 1; i++)
            {
                int j = i;
                while (j > 1 && comparer.Compare(array[j], array[i - 1]) < 0)
                {
                    swap(ref array[i], ref array[i - 1]);
                    j--;
                }
                Console.WriteLine();
                AlgorithmHelper.PrintArray(array);
            }
        }
        private static void swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }
    }
}
