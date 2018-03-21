using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
           // openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Filter = "Files|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                label1.Text = openFileDialog.FileName;
                string filePath = label1.Text;
                //label1.Image = Image.FromFile(ImagePath);
                string path = Application.StartupPath + "/" + filePath;
                FileInfo fileInfo = new FileInfo(path);

                string txtContent = System.IO.File.ReadAllText(filePath, Encoding.GetEncoding("gbk"));
                txtContent = txtContent.Replace("\r", "").Replace("\n", "").Replace("\t", "");
                List<string> creator = RegexMatchHtml("作者:", "所在学院", txtContent);
                List<string> school = RegexMatchHtml("所在学院:", "联系电话", txtContent);
                List<string> phone = RegexMatchHtml("联系电话:", "EMail", txtContent);
                List<string> mail = RegexMatchHtml("EMail:", "导师", txtContent);
                List<string> teacher = RegexMatchHtml("导师:", "学科专业", txtContent);
                List<string> major = RegexMatchHtml("学科专业:", "研究方向", txtContent);
                List<string> xy = RegexMatchHtml("研究方向:", "中文题名", txtContent);
                List<string> ztitle = RegexMatchHtml("中文题名:", "中文摘要", txtContent);
                List<string> zContent = RegexMatchHtml("中文摘要:", "外文摘要:", txtContent);
                List<string> eContent = RegexMatchHtml("外文摘要:", "关键词:", txtContent);
                List<string> subject = RegexMatchHtml("关键词:", "提交日期", txtContent);
                List<string> postTime = RegexMatchHtml("提交日期:", "文档总页数", txtContent);
                List<string> docLength = RegexMatchHtml("文档总页数:", "答辩日期", txtContent);
                List<string> dbTime = RegexMatchHtml("答辩日期:", "学位名称", txtContent);
                List<string> XWName = RegexMatchHtml("学位名称:", "学位授予单位", txtContent);
                List<string> XWFormat = RegexMatchHtml("学位授予单位:", "密级", txtContent);
                List<string> exTop = RegexMatchHtml("密级:", "附件", txtContent);
                List<string> tfilename = RegexMatchHtml("附件:", "!!", txtContent);
                List<List<string>> list = new List<List<string>>() { creator, school, phone, mail, teacher, major, xy, ztitle, zContent, eContent
            ,subject,postTime,docLength,dbTime ,XWName ,XWFormat,exTop ,tfilename
            };
            }
        }
        /// <summary>
        /// 获?取¨?区?域?¨°中D的ì?a标à¨o签?
        /// </summary>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="src"></param>
        /// <returns></returns>
        static List<string> RegexMatchHtml(string begin, string end, string src)
        {
            // begin <td> ·?è <a href=\"
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
