using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace CommonClass.Requires
{
    class test : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }
        protected string Request = string.Empty;
        public void ProcessRequest(HttpContext context)
        {
            Request = context.Request["Request"];//获取方法名称
            switch (Request)
            {
                case "Column": Load(context); break;
                default: break;
            }
        }
        public void Load(HttpContext context)
        {
            string content = System.IO.File.ReadAllText(@"D:\示范文件.txt", Encoding.GetEncoding("gbk"));
            List<string> auths = RegexMatchHtml("作者:", "\r\n所在学院:", content);
            List<string> sp = RegexMatchHtml("\r\n所在学院:", "\r\n联系电话:", content);

            FileInfo fileInfo = new FileInfo(Application.StartupPath + "\\part.xls");
            using (var excel = new ExcelPackage(fileInfo))
            {
                var ws = excel.Workbook.Worksheets.Add("Sheet1");
                ws.Cells[1, 1].Value = "编号";
                ws.Cells[1, 2].Value = "名称";
                ws.Cells[1, 3].Value = "层级";
                ws.Cells[1, 4].Value = "元数据模板";
                ws.Cells[1, 5].Value = "访问地址";
                ws.Cells[1, 6].Value = "分类编号";
                excel.Save();
            }


        }

        /// <summary>
        /// 获取区域中的a标签
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        static List<string> RegexMatchHtml(string begin, string end, string src)
        {
            // begin <td> · <a href=\"
            // end \" target=
            string parrern = begin + "(?<key>.*?)" + end;
            List<string> list = new List<string>();
            MatchCollection matchs = Regex.Matches(src, parrern);
            for (int i = 0; i < matchs.Count; i++)
            {
                list.Add(matchs[i].Groups[1].Value.Replace("\r\n", "").Trim());
            }
            return list;
        }

    }
}
