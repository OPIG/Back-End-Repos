using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 问题：一个数组，让它倒序输出  
/// 解决方法：暂未解决
/// </summary>
namespace demo1
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] a = { "5", "4", "3", "2", "1" };
            List<string> b = new List<string>();
            foreach (var item in a)
            {
                b.Add(item);
               // b.add(item);
            }
            Console.WriteLine(b.ToArray()); ;
        }
    }
}
