using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReadTxt
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StreamReader rd = new StreamReader(Server.MapPath("Site_Counter.txt")); //读取文件
            int count = int.Parse(rd.ReadLine());                                                                //把读到的值赋给变量count
            rd.Close();                                                                                                       //记得关闭读操作

            Label_count.Text = count.ToString();                                                             //这个label就是首页放的一个label你懂的
            int Site_Counter = Convert.ToInt32(count) + 1;                                            //把读到的count+1然后赋给变量Site_Counter ，累加
            StreamWriter wt = new StreamWriter(Server.MapPath("Site_Counter.txt"), false);   //写入txt
            wt.WriteLine(Site_Counter);                                                                                     //把刚才的那个累加后的Site_Counter 写入txt
            wt.Close();
        }
    }
}