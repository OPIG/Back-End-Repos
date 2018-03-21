using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertionSort
{
   public  class AlgorithmHelper
    {
        public static void PrintArray<T>(T[] array) {
            Console.Write(" Array:");
            foreach (T item in array) {
                Console.Write(" {0}",item);
            }
            Console.WriteLine();
        }
    }
}
