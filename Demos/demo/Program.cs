using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// <summary>
///问题： 两个无序的字符串，若对应的每个字符的总和相等就认为两个字符串相等 
/// 解决方案：用到数据字典
/// </summary>
namespace demo
{
    /// <summary>
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //CTL+F5运行 ，可查看到运行后的控制台结果
            #region //两个无序的字符串，若对应的每个字符的总和相等就认为两个字符串相等
            string str1 = "_$abcsaaa";
            string str2 = "cbas$_bba";
            #region //先比较两个字符串的长度是不是一致的
            if (str1.Length == str2.Length)
            {
                Dictionary<char, int> dict = new Dictionary<char, int>();//定义数据字典
                Dictionary<char, int> dict2 = new Dictionary<char, int>();//定义数据字典
                #region   //循环出第一个字符串中的每个字符
                foreach (char item in str1)
                {
                    //如果数据字典中包含当前字符
                    if (dict.ContainsKey(item))
                    {
                        //数据字典中对应字符的数量加1
                        dict[item] = dict[item] + 1;//这里需要去了解一下数据字典
                    }
                    else
                    {
                        //如果数据字典中不包含该字符，那么在数据字典中添加该字符
                        dict.Add(item, 1);
                    }
                }
                #endregion
                #region //循环出第二个字符串中的每个字符
                foreach (char item in str2)
                {
                    //如果数据字典中包含当前字符
                    if (dict2.ContainsKey(item))
                    {
                        //数据字典中对应字符的数量加1
                        dict2[item] = dict2[item] + 1;//这里需要去了解一下数据字典
                    }
                    else
                    {
                        //如果数据字典中不包含该字符，那么在数据字典中添加该字符
                        dict2.Add(item, 1);
                    }
                }
                #endregion
                var flag = 0;//定义一个全局变量
                #region //遍历第一个数据字典
                foreach (KeyValuePair<char, int> item in dict)
                {
                    //   Console.WriteLine(item.Key + "    " + item.Value);//输出当前字符键、值

                    //如果第二个数据字典中包含该字符
                    if (dict2.ContainsKey(item.Key))
                    {
                        //比较一下数据字典1中字符个数与数据字典2中的字符个数是否相等
                        if (item.Value == dict2[item.Key])
                        {

                            flag++;//如果相等全部变量添加1

                        }
                    }
                    else
                    {
                        //如果不匹配
                        Console.WriteLine("\n" + "还没匹配完我就知道匹配不成功了！" + "\n");
                        break;//没有比较下去的必要了
                    }
                }
                #endregion
                #region //最后比较一下字符总个数相等的数量与数据字典中字符的长度是不是一致的
                if (flag == str1.Length)
                {
                    //匹配成功
                    Console.WriteLine("\n" + "欧耶，匹配成功！(^o^)" + "\n");
                }
                else
                {
                    Console.WriteLine("\n" + "啊欧！匹配不成功！( ⊙ o ⊙ )" + "\n");
                }
                #endregion

                #region //遍历第二个数据字典
                //foreach (KeyValuePair<char, int> item in dict2)
                //{
                //    Console.WriteLine(item.Key + "    " + item.Value);//输出当前字符键、值
                //}
                #endregion
            }
            else
            {
                //长度就不一致，其他的都是扯淡
                Console.WriteLine("\n" + "两个字符串的长度都不一致！" + "\n");
            }
            #endregion
            #endregion
        }
    }
}
