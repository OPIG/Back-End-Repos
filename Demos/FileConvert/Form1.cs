using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void File_Import_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "Files|*.*";
                openFile.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    File_Name_cont.Text = openFile.FileName.ToString();//获取上传文件路径
                    string FileName_noExtension = System.IO.Path.GetFileNameWithoutExtension(File_Name_cont.Text);//获取文件名称不含后缀名
                    string FileName = System.IO.Path.GetFileName(File_Name_cont.Text);//获取文件名称（含后缀名）
                    string Extension = System.IO.Path.GetExtension(File_Name_cont.Text);//获取文件后缀名
                    string path = Application.StartupPath;
                    string SavePath = path.Replace("\\bin\\", "\\UpLoad\\").Replace("\\Debug", "\\Files");
                    if (!Directory.Exists(SavePath))
                    {
                        Directory.CreateDirectory(SavePath);
                    }
                    if (!File.Exists(SavePath + "/" + FileName)) {
                        SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();//输出文件  
                    }

                }
            }

            catch (Exception ex) {
               
                string strFileName = DateTime.Now.ToString("yyyyMMdd") + ".txt";
                string path = Application.StartupPath;
                string SavePath = path.Replace("\\bin\\", "\\Error\\").Replace("\\Debug", "");
                string strPath = SavePath+"/" + DateTime.Now.ToString("yyyyMMdd"); 
                if (!Directory.Exists(strPath)) {
                    Directory.CreateDirectory(strPath);
                }
                if (!File.Exists(SavePath + "/" + strFileName))
                {
                    FileStream fsl = new FileStream(SavePath + "/" + strFileName, FileMode.Create, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fsl);
                    sw.WriteLine(ex.Message.ToString());
                    sw.Close();
                    fsl.Close();
                }
                else {
                    FileStream fs1 = new FileStream(SavePath + "/" + strFileName, FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs1);
                    sw.WriteLine(ex.Message.ToString());
                    sw.Close();
                    fs1.Close();
                }
            }
        }
    }
}
