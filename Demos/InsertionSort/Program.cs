////插入排序
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 42, 20, 17, 13, 28, 14, 23, 15 };
            //int[] array = { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            AlgorithmHelper.PrintArray(array);

            SortAlgorithm.InsertSort
                (array, ComparerFactory.GetIntComparer());
        }
    }
}
