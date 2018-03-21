namespace FileConvert
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.File_Import = new System.Windows.Forms.Button();
            this.File_Name = new System.Windows.Forms.Label();
            this.File_Name_cont = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // File_Import
            // 
            this.File_Import.Location = new System.Drawing.Point(94, 48);
            this.File_Import.Name = "File_Import";
            this.File_Import.Size = new System.Drawing.Size(336, 61);
            this.File_Import.TabIndex = 0;
            this.File_Import.Text = "文件导入";
            this.File_Import.UseVisualStyleBackColor = true;
            this.File_Import.Click += new System.EventHandler(this.File_Import_Click);
            // 
            // File_Name
            // 
            this.File_Name.AutoSize = true;
            this.File_Name.Location = new System.Drawing.Point(92, 162);
            this.File_Name.Name = "File_Name";
            this.File_Name.Size = new System.Drawing.Size(77, 12);
            this.File_Name.TabIndex = 1;
            this.File_Name.Text = "导入文件名：";
            // 
            // File_Name_cont
            // 
            this.File_Name_cont.Location = new System.Drawing.Point(176, 152);
            this.File_Name_cont.Multiline = true;
            this.File_Name_cont.Name = "File_Name_cont";
            this.File_Name_cont.Size = new System.Drawing.Size(254, 42);
            this.File_Name_cont.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.File_Name_cont);
            this.Controls.Add(this.File_Name);
            this.Controls.Add(this.File_Import);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button File_Import;
        private System.Windows.Forms.Label File_Name;
        private System.Windows.Forms.TextBox File_Name_cont;
    }
}

